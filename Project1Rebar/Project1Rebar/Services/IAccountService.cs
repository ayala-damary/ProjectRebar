using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1Rebar.Services
{
    public class IAccountService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(string id);
        Order CreateOrder(Order order);
        void Update(string id, Order order);
        void DeleteOrder(string Id);
    }
}
