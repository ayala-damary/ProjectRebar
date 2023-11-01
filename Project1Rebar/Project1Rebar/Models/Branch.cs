using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1Rebar.Models
{
    public class Branch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("accounts")]
        public List<Account> Accounts { get; set; }
    }
}
