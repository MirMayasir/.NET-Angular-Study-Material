using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Deligatees
{
    internal class GenericDelegate
    {
        private static int result;
        public static void Main(string[] args)
        {
            /*Func<int, int, int> Addition = AddNumbers;
            int result = Addition(10, 20);
            Console.WriteLine($"Addition = {result}");*/

            /*Action<int, int> Addition = AddNumbers;
            AddNumbers(20, 10);
            Console.WriteLine(result);*/

            /*Action<int, int> Addition = (x,y) => result = (x + y);
            Addition(20, 20);
            Console.WriteLine(result);*/

            Predicate<string> CheckIsApple = IsApple;
            bool result = IsApple("Iphone 6");
            if(result)
            {
                Console.WriteLine("It is an iphone");
            }
            else
            {
                Console.WriteLine("android");
            }
        }

        public static bool IsApple(string modelName)
        {
            if (modelName == "Iphone 6s")
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        /*public static void AddNumbers(int x, int y)
        {
            result =  x + y;
        }*/
    }
}
