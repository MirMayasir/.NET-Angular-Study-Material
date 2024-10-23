using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Shape
    {

        public string colour { get; set; }
        public float Area { get; set; }

        public virtual void getDetails()
        {
            Console.WriteLine("enter the colour");
            colour = Console.ReadLine();
        }

        public virtual void CalculateArea()
        {
            Console.WriteLine("here we calculate the area of the shape");
        }

        public virtual void Display()
        {
            Console.WriteLine($" the colour of the shape is {colour}");
            Console.WriteLine($"area is {CalculateArea}");
        }
    }
    class Rectangle : Shape
    {
        public int length { set; get; }
        public int width { set; get; }
        public void getRectangleDetails()
        {
            Console.WriteLine("enter the length");
            length = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter the Breadth");
            width = Convert.ToInt32(Console.ReadLine());
        }

        public void CalculateRectangaleArea()
        {
            Area = length * width;
        }

        public void PrintRectangelDetails()
        {
            Console.WriteLine($"the area of the rectangle is {Area}");
        }
    }

    class Circle : Shape
    {
        public int radius { set; get; }

        public override void getDetails()
        {
            Console.WriteLine("enter the radius");
            radius = Convert.ToInt32(Console.ReadLine());
        }

        public override void CalculateArea()
        {
            base.CalculateArea();
            Area = (float)3.14 * radius * radius;
        }

        public override void Display()
        {
            Console.WriteLine($"the area of circle is : {Area}");
        }
    }

}