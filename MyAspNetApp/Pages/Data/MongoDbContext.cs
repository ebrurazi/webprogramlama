using MongoDB.Driver;
using MyAspNetApp.Pages.Models;

namespace MyAspNetApp.Pages.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var client = new MongoClient("mongodb+srv://username:password@cluster0.mongodb.net/");
            _database = client.GetDatabase("web");
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("users");
        public IMongoCollection<Role> Roles => _database.GetCollection<Role>("roles");
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("products");  // Products özelliğini ekleyin
    }
}
