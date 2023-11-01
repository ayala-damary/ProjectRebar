using MongoDB.Driver;
using Project1Rebar.Models;

namespace Project1Rebar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _order;
        public OrderService(IRebarDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _order = database.GetCollection<Order>(setting.OrdersCollection);

        }
        public Order CreateShakeInOrder(Order order)
        {
            _order.InsertOne(order);
            return order;
        }

        public List<Order> GetShakes()
        {
            return _order.Find(Order => true).ToList();
        }

        public Order GetShakeById(Guid id)
        {
            return _order.Find(order => order.Id == id).FirstOrDefault();
        }

        public void DeleteShake(Guid id)
        {
            _order.DeleteOne(order => order.Id == id);
        }

        public void UpdateOrderShake(Guid id, Order order)
        {
            _order.ReplaceOne(Order => Order.Id == id, order);
        }
    }
}
