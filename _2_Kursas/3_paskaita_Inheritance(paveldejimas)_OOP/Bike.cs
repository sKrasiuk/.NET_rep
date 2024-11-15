namespace _3_paskaita_Inheritance_paveldejimas__OOP
{
    public class Bike : Vehicle
    {
        public Bike(int speed)
        {
            Speed = speed;
        }

        public void PrintSpeed()
        {
            Console.WriteLine(Speed);
        }
    }
}
