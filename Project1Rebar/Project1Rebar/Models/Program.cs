namespace Project1Rebar.Models
{
    public class Program
    {
        public static bool IsValidName(string name)
        {
            if (name.Length < 3 || name.Length > 20)
            {
                Console.WriteLine("ccvg1");
                return false;
            }
            if (!char.IsLetter(name[0]))
            {
                Console.WriteLine("ccvg2");
                return false;
            }

            for (int i = 1; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]) || name[i] == '@')
                {
                    Console.WriteLine("ccvg3");
                    return false;
                }
            }
            Console.WriteLine("ccvg4");
            return true;
        }

        public static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.AddShake(new Shake("Chocolate Shake", "Delicious chocolate shake", 5, 6, 7));
            menu.AddShake(new Shake("Vanilla Shake", "Creamy vanilla shake", 5, 6, 7));
            menu.AddShake(new Shake("Strawberry Shake", "Refreshing strawberry shake", 5, 6, 7));

            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();

            Order order = new Order(customerName, menu);

            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Order Date: {order.OrderDate}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");

            Console.WriteLine("Ordered Shakes:");
            int i = 1;
            foreach (Shake shake in order.OrderedShakes)
            {
                Console.WriteLine($"{i}. {shake.Name} - {shake.Description}");
                i++;
            }

            Console.WriteLine($"Total Price: {order.TotalAmount:C}");
        }
    }
}
