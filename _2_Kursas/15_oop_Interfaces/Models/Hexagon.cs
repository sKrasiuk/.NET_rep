using _15_oop_Interfaces.Interfaces;

namespace _15_oop_Interfaces.Models
{
    internal class Hexagon : IPoligon
    {
        public double Side { get; set; }
        public double Area { get; private set; }

        public Hexagon(double side)
        {
            Side = side;
            Area = 3 * Math.Sqrt(3) / 2 * Math.Pow(Side, 2);
        }
        public double GetArea()
        {
            return Area;
        }
    }
}
