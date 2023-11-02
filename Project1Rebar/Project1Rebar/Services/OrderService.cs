using MongoDB.Driver;
using Project1Rebar.Models;
using System;
using System.Collections.Generic;

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

        public Shake CreateShakeInOrder(Shake shake)
        {
            //_order.InsertOne(shake);
            return shake;
        }

        //public List<Shake> GetShakes()
        //{
        //    return _order.Find(Order => true).ToList();
        //}

        //public Shake GetShakeById(Guid id)
        //{
        //    return _order.Find(order => order.Id == id).FirstOrDefault();
        //}

        public void DeleteShake(Guid id)
        {
            _order.DeleteOne(order => order.Id == id);
        }

        public object GetShakeById(Guid id)
        {
            throw new NotImplementedException();
        }

        //public void UpdateOrderShake(Guid id, Order order)
        //{
        //    _order.ReplaceOne(Order => Order.Id == id, order);
        //}

        public void UpdateOrderShake(Guid id, Shake shake)
        {
            //_order.ReplaceOne(Shake => Shake.Id == id, shake);
        }
    }
}
