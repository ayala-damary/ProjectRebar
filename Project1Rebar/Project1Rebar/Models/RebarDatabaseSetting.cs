namespace Project1Rebar.Models
{
    public class RebarDatabaseSetting : IRebarDatabaseSetting
    {
        public string OrdersCollection { get; set; }
        public string AccountCollectionName { get; set; } = string.Empty;
        public string MenuCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
