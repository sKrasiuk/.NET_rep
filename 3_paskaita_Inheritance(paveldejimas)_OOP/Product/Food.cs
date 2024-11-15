namespace _3_paskaita_Inheritance_paveldejimas__OOP.Product
{
    public class Food : Product
    {
        public DateOnly ExpirationDate { get; private set; }

        public Food(string name, double price) : base(name, price)
        {
            ExpirationDate = new DateOnly(2025, 01, 01);
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Exp.Date: {ExpirationDate}");
        }
    }
}
