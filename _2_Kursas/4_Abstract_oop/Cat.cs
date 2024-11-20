namespace _4_Abstract_oop
{
    public class Cat : Animal
    {
        public string Sound { get; set; } = "Miau Miau";

        //public Cat(string sound)
        //{
        //    Sound = sound;
        //}

        public override void MakeNoise()
        {
            Console.WriteLine(Sound);
        }
    }
}
