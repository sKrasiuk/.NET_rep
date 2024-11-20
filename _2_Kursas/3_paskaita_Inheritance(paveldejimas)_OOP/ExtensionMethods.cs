using _3_paskaita_Inheritance_paveldejimas__OOP.Models;

namespace _3_paskaita_Inheritance_paveldejimas__OOP
{
    public static class ExtensionMethods
    {
        public static void PrintAllInfo(this Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Product is null.");
                return;
            }

            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
        }
    }
}
