using _15_oop_Interfaces.Interfaces;

namespace _15_oop_Interfaces.Models
{
    internal class Pentagon : IPoligon
    {
        public double Side { get; set; }
        public double Apothem { get; set; }
        public double Area { get; private set; }

        public Pentagon(double side, double apothem)
        {
            Side = side;
            Apothem = apothem;
            Area = 5 / 2 * (Side * Apothem);
        }

        public double GetArea()
        {
            return Area;
        }
    }
}
