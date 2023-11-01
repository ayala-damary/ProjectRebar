using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Project1Rebar.Models
{
    public enum priceSize
    {       
        S = 15,
        M = 25,
        L = 30
    }
    [BsonIgnoreExtraElements]
    public class Shake
    {
        [BsonId]
        public Guid Id { get; }

        [BsonElement("name")]
        private String _name;

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("priceSize")]
        [BsonRepresentation(BsonType.String)]
        public priceSize PriceSize { get; set; }


        //public static int UniqueId = 0;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                try
                {
                    if (!Program.IsValidName(value)) throw new Exception("The valid name");
                    _name = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error Massage" + e.Message);
                }
            }
        }

     
        public Shake()
        {
            //Id = UniqueId++;
        }

        public Shake(String name, String description, priceSize priceSize)
        {
            //Id = UniqueId++;
            Name = name;
            Description = description;
            PriceSize = priceSize;

        }


    }
}
