using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_paskaita_OOP_class_methods
{
    internal class Rectangle
    {
        private int height { get; set; }
        private int width { get; set; }
        public double area { get; private set; }
        public double perimeter { get; private set; }


        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public double CalculateArea()
        {
            area = height * width;
            return area;
        }

        public double CalculatePerimeter()
        {
            perimeter = 2 * (height + width);
            return perimeter;
        }
    }
}
