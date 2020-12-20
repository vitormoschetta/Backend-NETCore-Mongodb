namespace Backend_NETCore_Mongodb
{
    public interface IMongoDbSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public string CollectionName { get; set ; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}