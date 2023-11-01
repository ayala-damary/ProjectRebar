namespace Project1Rebar.Models
{
    [BsonIgnoreExtraElements]
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("orders")]
        public List<Order> Orders { get; set; }

        [BsonElement("totalAmount")]
        private double _totalAmount;

        public double TotalAmount
        {
            get
            {
                return _totalAmount;
            }
            set
            {
                try
                {
                    if (_totalAmount < 0) throw new Exception("The valid total amount");
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error Massage" + e.Message);
                }
            }
        }

        public Account()
        {
            Orders = new List<Order>();
        }
    }
}
