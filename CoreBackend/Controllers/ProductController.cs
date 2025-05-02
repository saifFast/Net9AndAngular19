using CRUDBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Static list of Product
        private static List<Product> products = new List<Product>();

        //constructor
        public ProductController()
        {
            products.Add(new Product { Id = 1, Name = "Ball", Quantity = 1, Description = "Sports Material 1" });
            products.Add(new Product { Id = 2, Name = "Bat", Quantity = 1 , Description = "Sports Material 2" });
            products.Add(new Product { Id = 3, Name = "Cap", Quantity = 1 , Description = "Sports Material 3" });
        }

        //Create Product //Add Product
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        //Get Product By ID // Read Product
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


        //delete Product // remove Product
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var Product = products.FirstOrDefault(x => x.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            products.Remove(Product);
            return Product;
        }


        //Update Product
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var productToBeUpdated = products.FirstOrDefault(x => x.Id == product.Id);
            if (productToBeUpdated == null)
            {
                return NotFound();
            }

            productToBeUpdated.Name = product.Name;
            productToBeUpdated.Description = product.Description;
            productToBeUpdated.Quantity = product.Quantity;

            return NoContent();
        }
    }
}