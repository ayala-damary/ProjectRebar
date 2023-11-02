using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Project1Rebar.Models
{
    public class Menu
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("shakes")]
        public List<Shake> Shakes { get; set; }

        public Menu()
        {
            Shakes = new List<Shake>();
        }

        public void AddShake(Shake shake)
        {
            Shakes.Add(shake);
        }

    }
}
