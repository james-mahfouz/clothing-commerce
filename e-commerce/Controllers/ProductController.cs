﻿using e_commerce.Data;
using e_commerce.Models;
using e_commerce.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.Category.Title == request.Category));
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
                itemColor = p.ProductStyles.Where(s => s.ProductID == p.Id).Select(s=> s.Color).ToList(),
                itemSize = p.ProductStyles.Where(s => s.ProductID == p.Id).Select(s => s.Size).ToList(),
                shoppingCartData = new
                {
                    Quantity = 0
                }
            }).ToList();

            return Ok(filteredProducts);
        }
    }
}
