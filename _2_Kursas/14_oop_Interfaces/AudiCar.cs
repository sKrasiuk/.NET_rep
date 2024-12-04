namespace _14_oop_Interfaces
{
    internal class AudiCar : Car
    {
        public bool IsQuatro { get; set; }
        public AudiCar(string model, int fuel, bool isQuatro) : base(model, fuel)
        {
            IsQuatro = isQuatro;
        }
    }
}
