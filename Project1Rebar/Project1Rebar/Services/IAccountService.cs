using Project1Rebar.Models;
using System;
using System.Collections.Generic;

namespace Project1Rebar.Services
{
    public interface IAccountService
    {
        List<Order> GetOrders();
        Order GetOrderById(Guid id);
        Order CreateOrder(Order order);
        void UpdateOrder(Guid id, Order order);
        void DeleteOrder(Guid id);
    }
}
