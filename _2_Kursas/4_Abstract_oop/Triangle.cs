namespace _4_Abstract_oop
{
    internal class Triangle : GeometricShape
    {
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public override double GetArea()
        {
            return (SideB * Height) / 2;
        }


        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public Triangle(double sideA, double sideB, double sideC, double height)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Height = height;
        }
    }
}
