using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_One
{
    internal class Program7
    {
        static void Main(string[] args)
        {
            // for (int i = 1; i <=10; i++)
            // {
            //    if(i%2 != 0)
            //    {
            //        Console.WriteLine(i);
            //     }
            //  }

            // int i = 1;

            //do
            //{
            //  if (i % 2 != 0)
            //   {
            //       Console.WriteLine(i);
            //   }
            //   i++;
            //  }while (i<=10);

            int i = 1;
            while (i <= 10)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }
    }
}
