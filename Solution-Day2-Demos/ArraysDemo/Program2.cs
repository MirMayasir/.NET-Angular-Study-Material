using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Program2
    {
        static void Main()
        {
            // declare & initialize array
            int[] num1 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] num2 = new int[] { 1, 2, 3 };
            // in C# 7
            int[] num3 = [2, 3, 4];
            int sum = 0;
            foreach(int num in num1)
                sum += num;
            Console.WriteLine($"Sum is {sum}");
            float avg = (float)sum / num1.Length;
            Console.WriteLine($"Avg is {avg}");

            Console.WriteLine("enyter number");
            int x;
            x = Convert.ToByte(Console.ReadLine());

            byte temp1 = 25;
            float temp2 = 90.8f;
            double temp3 = 5678.8;
            string temp4 = "45";

            // conversions
            temp2 = temp1;   // implicit conversion
            temp1 = (byte)temp2; // expilicit conversion


            temp3 = temp2; // impilicit convesrion
            temp2 = (float) temp3;  // expilicit conversion

            // frm smaller type to bigger type, conversion happens
            // impilcit

            // frm bigger type to lower type, conversion has to do
            // explicit

            // because their base types are different

            temp1 = Convert.ToByte(temp4);
            char c = 'a';
            //temp4 = (string)c;
            temp4 = Convert.ToString(c);

            //c = (char)temp4;
            c = Convert.ToChar(temp4);

            Console.WriteLine("enter number");
            //int x1 = Convert.ToInt32(Console.ReadLine());
            int x1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter num");
            int temp = Byte.Parse(Console.ReadLine());


        }
    }
}
