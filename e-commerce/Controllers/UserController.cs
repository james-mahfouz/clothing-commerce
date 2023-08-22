using e_commerce.Data;
using e_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using e_commerce.Requests;


namespace e_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShopContext _context;

        public UserController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet("get_user"), Authorize]
        public async Task<IActionResult> GetUser()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string? userName = User.FindFirst(ClaimTypes.Name)?.Value;
            string lastName = User.FindFirst(ClaimTypes.Surname).Value;

            var userObject = new
            {
                firstName = userName,
                lastName = lastName
            };
            return await Task.FromResult(Ok(userObject));
        }

        [HttpGet("get_shopping_cart"), Authorize]
        public async Task<ActionResult> GetShoppingCart()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            Console.WriteLine(userId);
            var shoppingCartItems = await _context.ShoppingCarts
                .Where(cart => cart.Order.isBought == false && cart.Order.UserID == userId)
                .Include(cart => cart.ProductStyle)
                .Include(cart => cart.Order)
                .ThenInclude(order => order.User)
                .Select(cart => new
                {
                    ProductTitle = cart.ProductStyle.Product.Name,
                    ProductBrand = cart.ProductStyle.Product.Brand.Title,
                    Color = cart.ProductStyle.Color,
                    Size = cart.ProductStyle.Size,
                    Image = cart.ProductStyle.ProductImageLink,
                    Price = cart.ProductStyle.Product.Price,
                    Quantity = cart.ItemQuantity,
                    cartId = cart.ID
                })
                .ToListAsync();
            bool isEmpty = !shoppingCartItems.Any();
            if (isEmpty)
            {
                return Ok("Your Shopping cart is empty");
            }

            decimal totalPrice = shoppingCartItems.Sum(item => item.Price * item.Quantity);

            return Ok(new { ShoppingCartItems = shoppingCartItems, TotalPrice = totalPrice });
        }

        [HttpPost("add_product_to_cart/{ProductId}"), Authorize]
        public async Task<IActionResult> AddProductToCart(int ProductId, AddProductToCartRequest request)
        {
            try
            {
                int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var Product = await _context.Products.FindAsync(ProductId);

                var existingProductStyle = await _context.ProductStyle
                    .FirstOrDefaultAsync(style => style.ProductID == ProductId
                                       && style.ColorID == request.Color
                                       && style.SizeID == request.Size);

                if (existingProductStyle == null)
                {
                    return NotFound("we don't have This Color Size combination anymore");
                }
                else if (existingProductStyle.Quantity < request.Quantity)
                {
                    return BadRequest("There aren't enough items");
                }
                else if (request.Quantity <= 0)
                {
                    return BadRequest("please select a viable quantity");
                }
                var existingCartItem = await _context.ShoppingCarts
                    .FirstOrDefaultAsync(cart => cart.Order.UserID == userId && cart.Order.isBought==false && cart.ProductStyleID == existingProductStyle.ID);

                if (existingCartItem != null)
                {
                    return BadRequest("the item is already in the cart");
                }

                var existingOrder = await _context.Orders
                    .FirstOrDefaultAsync(order => order.UserID == userId && order.isBought == false);

                if (existingOrder == null)
                {
                    existingOrder = new Order
                    {
                        isBought = false,
                        price = (float)Product.Price,
                        UserID = userId
                    };
                    _context.Orders.Add(existingOrder);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    existingOrder.price = (float)existingOrder.price + (float)Product.Price;
                }

                var cartItem = new ShoppingCart
                {
                    OrderID = existingOrder.ID,
                    ProductStyleID = existingProductStyle.ID,
                    ItemQuantity = request.Quantity,
                };

                _context.ShoppingCarts.Add(cartItem);
                await _context.SaveChangesAsync();

                return Ok("product style added to shopping cart");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occured: {ex.Message}");
            }
        }

        [HttpPost("remove_product_from_cart/{ProductId}"), Authorize]
        public async Task<IActionResult> RemoveFromCart(int ProductId)
        {
            try
            {
                var cartItem = await _context.ShoppingCarts.FindAsync(ProductId);

                if (cartItem == null)
                {
                    return NotFound("Item not found in the cart");
                }

                _context.ShoppingCarts.Remove(cartItem);
                await _context.SaveChangesAsync();

                return Ok("Product style removed from the shopping cart");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occured: {ex.Message}");
            }
        }

        [HttpGet("checkout"), Authorize]
        public async Task<IActionResult> checkout()
        {
            try
            {

                int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                var orderToBuy = await _context.Orders.FirstOrDefaultAsync(order => order.UserID == userId && order.isBought == false);
                if (orderToBuy == null)
                {
                    return NotFound("you don't have an order");
                }
                var orderItems = await _context.ShoppingCarts
                    .Where(cart => cart.OrderID == orderToBuy.ID)
                    .ToListAsync();


                if (orderItems.Count == 0)
                {
                    return BadRequest("your order is empty");
                }

                orderToBuy.isBought = true;
                await _context.SaveChangesAsync();
                return Ok("order has been bought");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"ann error occured: {ex.Message}");
            }
        }

    }
}
