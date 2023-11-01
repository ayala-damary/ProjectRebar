using MongoDB.Bson.Serialization.Attributes;

namespace Project1Rebar.Models
{
    public interface IRebarDatabaseSetting
    {
        public string OrdersCollection { get; set; }
        string AccountCollectionName { get; set; }
        string MenuCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
 
    }
}
