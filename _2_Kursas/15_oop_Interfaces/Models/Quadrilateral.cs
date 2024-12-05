using _15_oop_Interfaces.Interfaces;

namespace _15_oop_Interfaces.Models
{
    internal class Quadrilateral : IPoligon
    {
        public double Height { get; set; }
        public double Base { get; set; }
        public double Area { get; private set; }

        public Quadrilateral(double height, double Base)
        {
            this.Base = Base;
            Height = height;
            Area = Height * Base;
        }
        public double GetArea()
        {
            return Area;
        }
    }
}
