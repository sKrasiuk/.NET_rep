namespace _4_Abstract_oop
{
    internal class Square : GeometricShape
    {
        public double Side { get; set; }

        public override double GetArea()
        {
            return Math.Pow(Side, 2);
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
        }

        public Square(double side)
        {
            Side = side;
        }
    }
}
