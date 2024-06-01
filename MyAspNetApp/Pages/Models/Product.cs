using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyAspNetApp.Pages.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }
    }
}
