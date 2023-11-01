using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1Rebar.Services
{
    public static bool IsValidName(string name)
    {
        string nameConsumer = "^[A-Za-z]+$";
        if (name.Length < 3 || name.Length > 20 || !char.IsLetter(name[0]) || !Regex.IsMatch(order.NameCustomer, nameConsumer))
        {
            return false;
        }
        return true;
    }

    public class AccountService
    {
        private readonly IMongoCollection<Order> _orders;
        public AccountService(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.AccountCollectionName);
        }

        public Order CreateOrder(Order order)
        {
            try
            {
                if (order.ListShakes.Count > 10)
                    throw new Exception($"Order:{order.Id} was not made-You cannot order more than 10 shakesed!");
                bool nameConsumer = IsValidName(order.NameCustomer);
                if (!nameConsumer)
                    throw new Exception($"In order:{order.Id} this customers dos'nt exsist ");
                if (order.ListShakes.Count <= 0)
                    throw new Exception($"the number order {order.Id} The customer did not select any shakes");
                foreach (var shakes in order.ListShakes)
                {
                    order.TotalPrice += (decimal)shakes.PriceSize;
                }
                _orders.InsertOne(order);
                Console.WriteLine($"Order: {order.Id} enter and the total price: {order.TotalPrice}");
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine("The error" + e.Massage);
            }
        }

        public void DeleteOrder(string id)
        {
            _orders.DeleteOne(order => order.Id == id);

        }

        public List<Order> GetOrders()
        {
            return _orders.Find(orders => true).ToList();
        }

        public Order GetOrderById(string id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();

        }

        public void UpdateOrder(string id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order);

        }
    }
}
