using System;
using System.Collections.Generic;
using System.Linq;
using Project1Rebar.Models;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace Project1Rebar.Services
{
    public class AccountService: IAccountService
    {
        private readonly IMongoCollection<Order> _orders;
        public AccountService(IRebarDatabaseSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.AccountCollection);
        }
        public Order CreateOrder(Order order)
        {
            try
            {
                if (order.Shakes.Count > 10)
                {
                    throw new Exception($"Order:{order.Id} was not made - You cannot order more than 10 shakes!");
                }

                bool nameValid = IsValidName(order.CustomerName);
                if (!nameValid)
                {
                    throw new Exception($"In order:{order.Id} this customer doesn't exist.");
                }
                if (order.Shakes.Count == 0)
                {
                    throw new Exception($"Order {order.Id} - The customer did not select any shakes.");
                }

                foreach (var shake in order.Shakes)
                {
                    order.TotalAmount += (decimal)shake.PriceSize;
                }
                _orders.InsertOne(order);

                Console.WriteLine($"Order: {order.Id} has been created, and the total price is: {order.TotalAmount}");
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                throw; 
            }
        }


        public static bool IsValidName(string name)
        {
            string nameConsumer = "^[A-Za-z]+$";
            if (name.Length < 3 || name.Length > 20 || !char.IsLetter(name[0]) || !(Regex.IsMatch(name, nameConsumer)))
            {
                return false;
            }
            return true;
        }

        public void DeleteOrder(Guid id)
        {
            _orders.DeleteOne(order => order.Id == id);

        }

        public List<Order> GetOrders()
        {
            return _orders.Find(orders => true).ToList();
        }

        public Order GetOrderById(Guid id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();

        }

        public void UpdateOrder(Guid id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order);

        }
    }
}
