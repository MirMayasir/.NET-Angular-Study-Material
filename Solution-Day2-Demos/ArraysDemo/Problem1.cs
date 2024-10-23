using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Problem1
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            int sum = 0;
            Console.WriteLine("enter the elements");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = Convert.ToByte(Console.ReadLine());
                sum += array[i];
                
            }
            float avg = 0;
            avg = (float) sum / array.Length;
            Console.WriteLine($"the sum of array is {sum}");
            Console.WriteLine($"the average of the array is {avg}");
        }
    }
}
