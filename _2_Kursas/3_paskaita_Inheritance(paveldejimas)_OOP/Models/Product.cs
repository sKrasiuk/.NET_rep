namespace _3_paskaita_Inheritance_paveldejimas__OOP.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
        }
    }
}
