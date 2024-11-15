namespace _3_paskaita_Inheritance_paveldejimas__OOP.Product
{
    public class Electronic : Product
    {
        public DateOnly Warranty { get; private set; }

        public Electronic(string name, double price) : base(name, price)
        {
            Warranty = new DateOnly(2026, 11, 28);
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Warranty date: {Warranty}");
        }
    }
}
