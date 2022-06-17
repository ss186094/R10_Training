using HPlusSport.API.Classes;
using HPlusSport.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSport.API.Controllers
{
    [ApiVersion("1.0")]
    //[Route("v{v:apiversion}/product")]
    [Route("product")]
    [ApiController]
    public class ProductV1_0Controller : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductV1_0Controller(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _context.Products.ToArray();
        //}



        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]ProductQueryParameters queryparameters)
        {
            IQueryable<Product> products = _context.Products;
            if(queryparameters.MinPrice!=null && queryparameters.MaxPrice != null)
            {
                products = products.Where(p => p.Price >= queryparameters.MinPrice.Value && p.Price <= queryparameters.MaxPrice.Value);

            }
            if (!string.IsNullOrEmpty(queryparameters.Sku))
            {
                products = products.Where(p => p.Sku == queryparameters.Sku);
            }

            if (!string.IsNullOrEmpty(queryparameters.Name))
            {
                products = products.Where(p => p.Name.ToLower().Contains(queryparameters.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(queryparameters.SearchTerm))
            {
                products = products.Where(p => p.Sku.ToLower().Contains(queryparameters.SearchTerm.ToLower()) || p.Name.ToLower().Contains(queryparameters.SearchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryparameters.SortBy))
            {
                if (typeof(Product).GetProperty(queryparameters.SortBy) != null)
                {
                    products = products.OrderByCustom(queryparameters.SortBy, queryparameters.SortOrder);
                }
            }
            products = products.Skip(queryparameters.Size * (queryparameters.Page - 1)).Take(queryparameters.Size);
            return Ok(await products.ToArrayAsync());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product =await  _context.Products.FindAsync(id);

            if(product== null)
            {
                return NotFound();
            }
            return Ok(product);
        }




        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody]Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", 
                new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Products.Find(id) == null)
                {
                    return NotFound();
                }
                throw;
            }
           

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }





        [HttpPost("{id}")]
        [Route("Delete")]
        public async Task<ActionResult<Product>> DeleteMultiple([FromQuery]int[] ids)
        {
            var products = new List<Product>();
            foreach(var id in ids)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                products.Add(product);
            }
            
            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
            return Ok(products);
        }





    }

























    [ApiVersion("2.0")]
    //[Route("v{v:apiversion}/product")]
    [Route("product")]
    [ApiController]
    public class ProductV2_0Controller : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductV2_0Controller(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _context.Products.ToArray();
        //}



        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductQueryParameters queryparameters)
        {
            IQueryable<Product> products = _context.Products.Where(p=> p.IsAvailable==true);
            if (queryparameters.MinPrice != null && queryparameters.MaxPrice != null)
            {
                products = products.Where(p => p.Price >= queryparameters.MinPrice.Value && p.Price <= queryparameters.MaxPrice.Value);

            }
            if (!string.IsNullOrEmpty(queryparameters.Sku))
            {
                products = products.Where(p => p.Sku == queryparameters.Sku);
            }

            if (!string.IsNullOrEmpty(queryparameters.Name))
            {
                products = products.Where(p => p.Name.ToLower().Contains(queryparameters.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(queryparameters.SearchTerm))
            {
                products = products.Where(p => p.Sku.ToLower().Contains(queryparameters.SearchTerm.ToLower()) || p.Name.ToLower().Contains(queryparameters.SearchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryparameters.SortBy))
            {
                if (typeof(Product).GetProperty(queryparameters.SortBy) != null)
                {
                    products = products.OrderByCustom(queryparameters.SortBy, queryparameters.SortOrder);
                }
            }
            products = products.Skip(queryparameters.Size * (queryparameters.Page - 1)).Take(queryparameters.Size);
            return Ok(await products.ToArrayAsync());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }




        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct",
                new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Products.Find(id) == null)
                {
                    return NotFound();
                }
                throw;
            }


            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }





        [HttpPost("{id}")]
        [Route("Delete")]
        public async Task<ActionResult<Product>> DeleteMultiple([FromQuery] int[] ids)
        {
            var products = new List<Product>();
            foreach (var id in ids)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                products.Add(product);
            }

            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
            return Ok(products);
        }





    }


















}
