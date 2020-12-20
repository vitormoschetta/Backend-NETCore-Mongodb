using System.Collections.Generic;
using Backend_NETCore_Mongodb.Models;
using MongoDB.Driver;

namespace Backend_NETCore_Mongodb.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.CollectionName);
        }

        public List<Product> Get() =>
            _products.Find(x => true).ToList();

        public Product Get(string id) =>
            _products.Find<Product>(x => x.Id == id).FirstOrDefault();

        public Product Create(Product model)
        {
            _products.InsertOne(model);
            return model;
        }

        public void Update(string id, Product model) =>
            _products.ReplaceOne(x => x.Id == id, model);

        public void Remove(Product model) =>
            _products.DeleteOne(x => x.Id == model.Id);

        public void Remove(string id) => 
            _products.DeleteOne(x => x.Id == id);
    }
}