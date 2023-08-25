using e_commerce.Data;
using e_commerce.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace e_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductController(ShopContext context)
        {
            _context = context;
        }


        [HttpPost("get_product")]
        public IActionResult GetAllProducts([FromBody] FilterProductRequest request)
        {
            var query = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductStyles)
                .Include(p => p.ProductCategories)
                .AsQueryable(); // Convert to IQueryable to build dynamic query


            if (request.BrandID?.Count > 0)
            {
                query = query.Where(p => request.BrandID.Contains(p.BrandID));
            }

            if (request.ColorID != 0)
            {
                query = query.Where(p => p.ProductStyles.Any(ps => ps.ColorID == request.ColorID));
            }

            if (request.CategoryID != 0 )
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.Category.Id == request.CategoryID));
            }

            if (request.SizeID != 0)
            {
                query = query.Where(p => p.ProductStyles.Any(ps => ps.SizeID == request.SizeID));
            }

            if (request.minPrice != 0)
            {
                query = query.Where(p => p.Price >= request.minPrice);
            }

            if (request.maxPrice != 0)
            {
                query = query.Where(p => p.Price <= request.maxPrice);
            }

            if (request.MaterialID?.Count > 0)
            {
                query = query.Where(p => request.MaterialID.Contains(p.MaterialID));
            }

            query = query.Where(p =>
            p.ProductStyles.Any(ps => ps.Color != null) &&
            p.ProductStyles.Any(ps => ps.Size != null));

            var filteredProducts = query.Select(p => new
            {
                ProductID = p.Id,
                ProductName = p.Name,
                BrandID = p.BrandID,
                BrandTitle = p.Brand.Title,
                ImageLink = p.ProductImageLink,
                Price = p.Price,
                New = p.New,
                Sale = p.Sale,
                itemColor = p.ProductStyles.Where(s => s.ProductID == p.Id).Select(s => s.Color).ToList(),
                itemSize = p.ProductStyles
                    .Where(s => s.ProductID == p.Id)
                    .Select(s => s.Size)
                    .Distinct()
                    .OrderBy(s => s)
                    .ToList(),
                shoppingCartData = new
                {
                    Quantity = 0
                }
            }).ToList();

            return Ok(filteredProducts);
        }

        [HttpPost("getSizeByColor")]
        public IActionResult GetAllProducts([FromBody] GetSizeByColorRequest request)
        {
            try
            {
                var sizes = _context.ProductStyle
                    .Where(ps => ps.ProductID == request.ProductID &&
                    ps.ColorID == request.ColorID)
                    .Select(ps => new
                    {
                        id = ps.SizeID,
                        SizeNumber = ps.Size.SizeNumber
                    })
                    .Distinct()
                    .OrderBy(s => s.SizeNumber)
                    .ToList();

                return Ok(sizes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get_categories")]
        public async Task<ActionResult> GetCategories()
        {
           
            var categories = await _context.Categories
                .Select(cat => new
                {
                    id = cat.Id,
                    title = cat.Title
                })
                .ToListAsync();

            return Ok(categories);
        }

        [HttpGet("get_brand")]
        public async Task<ActionResult> GetBrand()
        {

            var brands = await _context.Brands
                .Select(b => new
                {
                    id = b.ID,
                    title = b.Title
                })
                .ToListAsync();

            return Ok(brands);
        }

        [HttpGet("get_colors")]
        public async Task<ActionResult> GetColor()
        {

            var colors = await _context.Colors
                .Select(c => new
                {
                    id = c.ID,
                    title = c.ColorName,
                    hex = c.ColorHex
                })
                .ToListAsync();

            return Ok(colors);
        }

        [HttpGet("get_size")]
        public async Task<ActionResult> GetSize()
        {

            var sizes = await _context.Sizes
                .Select(s => new
                {
                    id = s.ID,
                    title = s.SizeNumber
                })
                .ToListAsync();

            return Ok(sizes);
        }

        [HttpGet("get_material")]
        public async Task<ActionResult> GetMaterial()
        {

            var materials = await _context.Materials
                .Select(s => new
                {
                    id = s.ID,
                    title = s.Title
                })
                .ToListAsync();

            return Ok(materials);
        }
    }
}
