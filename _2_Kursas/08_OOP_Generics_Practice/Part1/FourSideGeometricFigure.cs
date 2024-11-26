namespace _08_OOP_Generics_Practice.Part1
{
    public class FourSideGeometricFigure
    {
        public string Name { get; private set; }
        public double Base { get; private set; }
        public double Height { get; private set; }

        public FourSideGeometricFigure(string name, double sideA, double sideB)
        {
            Name = name;
            Base = sideA;
            Height = sideB;
        }

        private double GetArea()
        {
            if (Base == Height)
            {
                return Math.Pow(Base, 2);
            }
            return Base * Height;
        }

        public override string ToString()
        {
            return $"Name: {Name} | Base: {Base} | Height: {Height} | Area: {GetArea():F2}";
        }
    }
}
