using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_NETCore_Mongodb.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}