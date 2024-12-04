namespace _14_oop_Interfaces
{
    internal class BmwCar : Car
    {
        public bool IsXDrive { get; set; }
        public BmwCar(string model, int fuel, bool isXDrive) : base(model, fuel)
        {
            IsXDrive = isXDrive;
        }
    }
}
