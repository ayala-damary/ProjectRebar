
using Project1Rebar.Models;
using System;

namespace Project1Rebar.Services
{
    public class IAccountService
    {
        List<Order> GetOrders();
        Order GetOrderById(Guid id);
        Order CreateOrder(Order order);
        void UpdateOrder(Guid id, Order order);
        void DeleteOrder(Guid Id);
    }
}
