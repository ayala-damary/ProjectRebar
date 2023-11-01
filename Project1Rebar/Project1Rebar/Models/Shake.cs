using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Project1Rebar.Models
{
    [BsonIgnoreExtraElements]
    public class Shake
    {
        [BsonId]
        public Guid Id { get; }

        [BsonElement("name")]
        private String _name;

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("priceS")]
        [BsonRepresentation(BsonType.Decimal128)]     
        private decimal _priceS;

        [BsonElement("priceM")]
        [BsonRepresentation(BsonType.Decimal128)]
        private decimal _priceM;

        [BsonElement("priceL")]
        [BsonRepresentation(BsonType.Decimal128)]
        private decimal _priceL;

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

        public decimal PriceL
        {
            get
            {
                return _priceL;
            }
            set
            {
                try
                {
                    if (_priceL < 0) throw new Exception("The valid price");
                    _priceL = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error Massage" + e.Message);
                }
            }
        }
        public decimal PriceM
        {
            get
            {
                return _priceM;
            }
            set
            {
                try
                {
                    if (_priceM < 0) throw new Exception("The valid price");
                    _priceM = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error Massage" + e.Message);
                }
            }
        }

        public decimal PriceS
        {
            get
            {
                return _priceS;
            }
            set
            {
                try
                {
                    if (_priceS < 0) throw new Exception("The valid price");
                    _priceS = value;
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

        public Shake(String name, String description, decimal priceL, decimal priceM, decimal priceS)
        {
            //Id = UniqueId++;
            Name = name;
            Description = description;
            PriceL = priceL;
            PriceM = priceM;
            PriceS = priceS;

        }


    }
}
