using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1Rebar.Models;
using Project1Rebar.Services;

namespace Project1Rebar.Controllers
{
    public class Valid
    {
        public string orderValid(Order order)
        {
            if (string.IsNullOrEmpty(order.NameCustomer))
            {
                return "Customer name empty";
            }
            if (order.Shakes == null || order.Shakes.Count == 0)
            {
                return "The least empty";
            }
            if (!DateTime.TryParse(order.DateOrder.ToString(), out _))
            {
                return "Invalid DateOrder format";
            }
            if (!Enum.IsDefined(typeof(Discounts), order.Discounts))
            {
                return "Invalid discounts";
            }

            return "true";
        }

        public string shakeValid(Shake shake)
        {
            if (string.IsNullOrEmpty(shake.Name))
            {
                return "Shake name empty";
            }
            if (!Enum.IsDefined(typeof(priceSize), shake.PriceSize))
            {
                return "Invalid Price size";
            }
            if (string.IsNullOrEmpty(shake.Description))
            {
                return "Description empty";
            }
            return "true";
        }
    }
}
