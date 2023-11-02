using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Project1Rebar.Models
{
    public enum Discounts { 
        age20 = 20,
        disabled = 40,
        employee = 42 
    }
    public class Order
    {
        [BsonId]
        public Guid Id { get; }

        [BsonElement("shakes")]
        public List<Shake> Shakes { get; set; }

        [BsonElement("totalAmount")]
        private decimal _totalAmount;

        [BsonId]
        public Guid OrderId { get; set; }
 
        [BsonElement("customerName")]
        private string _customerName { get; set; }
     
        [BsonElement("orderDate")]
        private DateTime _orderDate { get; set; }

        [BsonElement("discounts")]
        public Discounts Discounts { get; set; }

        [BsonElement("orderedShakes")]
        public  List<Shake> OrderedShakes;

        public decimal TotalAmount
        {
            get
            {
                return _totalAmount;
            }
            set
            {
                try
                {
                    if (_totalAmount < 0) throw new Exception("Is valid total Amount");
                    _totalAmount = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error Massage" + e.Message);
                }
            }
        }

        public String CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                try
                {
                    if (!Program.IsValidName(value)) throw new Exception("The valid name");
                    _customerName = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error Massage" + e.Message);
                }
            }
        }


        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                try
                {
                    if (value < DateTime.Now) throw new Exception("The valid name");
                    _orderDate = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error Massage" + e.Message);
                }
            }
        }

        public Order()
        {
            Id = Guid.NewGuid();
        }

        public Order(string customerName, Menu menu)
        {
            OrderedShakes = new List<Shake>();
            CustomerName = customerName;
            OrderId = Guid.NewGuid();
            OrderDate = DateTime.Now;

            //Console.WriteLine("Menu:");
            //int i = 1;
            //foreach (Shake shake in menu.Shakes)
            //{
            //    Console.WriteLine($"{i}. {shake.Name} - {shake.Description} - Price (S/M/L): {shake.PriceSize}");
            //    i++;
            //}

            //Console.WriteLine("Select shakes by entering their numbers (1, 2, 3, etc.), separated by spaces:");

            //string[] selections = Console.ReadLine().Split(' ');

            //foreach (string selection in selections)
            //{
            //    if (int.TryParse(selection, out int shakeNumber) && shakeNumber > 0 && shakeNumber <= menu.Shakes.Count)
            //    {
            //        Shake selectedShake = menu.Shakes[shakeNumber - 1];
            //        OrderedShakes.Add(selectedShake);
            //        //TotalAmount += int.Parse(selectedShake.PriceSize);
            //    }
            //}

        }
    }
}
