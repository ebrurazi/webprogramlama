using MongoDB.Driver;
using MyAspNetApp.Pages.Models;

namespace MyAspNetApp.Pages.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://zehra:1234@cluster0.n8aotxw.mongodb.net/");
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(30); // Zaman aşımı süresini artırdık

            var client = new MongoClient(settings);
            _database = client.GetDatabase("web");
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("web3");
        public IMongoCollection<Role> Roles => _database.GetCollection<Role>("roles");
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("products");
    }
}
