namespace _4_Abstract_oop
{
    public class Dog : Animal
    {
        public string Sound { get; set; } = "AU AU";

        //public Dog(string sound)
        //{
        //    Sound = sound;
        //}

        public override void MakeNoise()
        {
            Console.WriteLine(Sound);
        }
    }
}
