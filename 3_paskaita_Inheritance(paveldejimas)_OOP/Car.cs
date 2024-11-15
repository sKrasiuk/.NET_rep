namespace _3_paskaita_Inheritance_paveldejimas__OOP
{
    public class Car : Vehicle
    {
        public Car(int speed)
        {
            Speed = speed;
        }

        public void PrintSpeed()
        {
            Console.WriteLine(Speed);
        }
    }
}
