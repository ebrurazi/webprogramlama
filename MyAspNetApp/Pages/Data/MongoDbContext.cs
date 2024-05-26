using MongoDB.Driver;
using MyAspNetApp.Pages.Models;

namespace MyAspNetApp.Pages.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {

           

            var client = new MongoClient("mongodb+srv://zehra:1234@cluster0.n8aotxw.mongodb.net/");
            _database = client.GetDatabase("web");
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("web3");
    }
}
