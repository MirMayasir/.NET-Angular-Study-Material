using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_One
{
    internal class Program3
    {
        static void Main()
        {
            int num1, num2;

            Console.WriteLine("enter num1");
            num1 = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("enter the num2");
            num2 = Convert.ToByte(Console.ReadLine());

            int ch;
            Console.WriteLine("enter your choice");
            ch = Convert.ToByte(Console.ReadLine());

            if (ch == 1)
            {
                Console.WriteLine($"the sum of {num1} and {num1} is {num1 + num2}");
            }

            else if (ch == 2)
            {
                Console.WriteLine($"the product of {num1} and {num1} is {num1 * num2}");
            }

            else if (ch == 3)
            {
                Console.WriteLine($"the quotient of {num1} and {num1} is {num1 / num2}");
            }

            else {
                Console.WriteLine("invalid choice");
                
            }


            
         
        }
    }
}
