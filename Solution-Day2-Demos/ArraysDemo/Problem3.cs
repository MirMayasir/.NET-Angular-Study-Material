using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Problem3
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int maxElement = 0;
            Console.WriteLine("enter the elements of an array");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToByte(Console.ReadLine());
                if(array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }
            Console.WriteLine($"the maximum elements of the array is {maxElement}.");
        }
    }
}
