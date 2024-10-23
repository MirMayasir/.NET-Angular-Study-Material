using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_One
{
    internal class Program8
    {
        static void Main(string[] args)
        {
            int choice;
              Console.WriteLine("enter your choice");
              choice = Convert.ToByte(Console.ReadLine());

            // for (int i = 0; i <= 10; i++)
            // {
            //   Console.WriteLine($"{choice} * {i} = {choice * i}");
            //}
            int i = 1;
            while(i <= 10)
            {
                Console.WriteLine($"{choice} * {i} = {choice * i}");
                i++;
            }
        }
    }
}
