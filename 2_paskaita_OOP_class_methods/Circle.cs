using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_paskaita_OOP_class_methods
{
    internal class Circle
    {
        public int radius { get; private set; }

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * radius;
            return perimeter;
        }
    }
}
