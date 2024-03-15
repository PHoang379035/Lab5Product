using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lab5Product.Models;

namespace Lab5Product.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private static List<Product> products = new List<Product>();
            // GET: api/Products
            [HttpGet]
            public ActionResult<IEnumerable<Product>> Get()
            {
                return Ok(products);
            }
            // GET: api/Products/5
            [HttpGet("{index}")]
            public ActionResult<Product> Get(int index)
            {
                if (index < products.Count)
                    return Ok(products[index]);
                else
                    return NotFound();
            }

            // POST: api/Products
            [HttpPost]
            public ActionResult Post([FromBody] Product product)
            {
                products.Add(product);
                return Ok("Product added successfully");
            }

            // PUT: api/Products/5
            [HttpPut("{index}")]
            public ActionResult Put(int index, [FromBody] Product product)
            {
                if (index < products.Count)
                {
                    products[index] = product;
                    return Ok("Product updated successfully");
                }
                else
                    return NotFound();
            }

            // DELETE: api/Products/5
            [HttpDelete("{index}")]
            public ActionResult Delete(int index)
            {
                if (index < products.Count)
                {
                    products.RemoveAt(index);
                    return Ok("Product deleted successfully");
                }
                else
                    return NotFound();
            }
        }
}
