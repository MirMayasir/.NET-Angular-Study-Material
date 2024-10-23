using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Program3
    {
        static void Main()
        {

            int[,] matrix = new int[3, 3] 
                {
                { 10,2,3},
                { 12,33,4},
                { 4,7,9}
            };
           

            //int[,] matrix = new int[3, 3];
            //Console.WriteLine("enter numbers");
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)

            //    {
            //        matrix[i, j] = Byte.Parse(Console.ReadLine());
            //    }
            //}

            Console.WriteLine("elements are ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
            }
        }
    }
}
