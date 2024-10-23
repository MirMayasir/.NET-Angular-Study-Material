using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Problem2
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3, 3];
            int sum = 0;

            Console.WriteLine("enter the elements ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = Convert.ToByte(Console.ReadLine());
                    sum += array[i, j];
                }
            }
            Console.WriteLine($"the sum of 3D array is {sum}");
        }
    }
}
