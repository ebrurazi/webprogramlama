using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MyAspNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMongoCollection<Product> _products;

        public ProductsController(IMongoClient client)
        {
       
            var database = client.GetDatabase("yeni");
            _products = database.GetCollection<Product>("web");
           

        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            product.Id = ObjectId.GenerateNewId();
            _products.InsertOne(product);
            return Ok(new { message = "Ürün başarıyla eklendi", productId = product.Id });
        }
        [HttpPost]
    public async Task<IActionResult> PostProduct([FromBody] Product product)
    {
        await _products.InsertOneAsync(product);
        return Ok(product);
    }
    
    
    }

    public class Product
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
