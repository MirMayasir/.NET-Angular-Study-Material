using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Problem5
    {
        static void Main(string[] args)
        {
            int[,] array = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

           int rows = array.GetLength(0);
           int columns = array.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int sum = 0;
                for (int col = 0; col < columns; col++)
                {
                    sum += array[row, col];
                }
                Console.WriteLine("Sum of row {0}: {1}", row + 1, sum);
            }
        }
    }
}
