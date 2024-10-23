using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deligatees
{
    internal class MulticastDelegates
    {
        public delegate void  PrintDel(string message);
        public static void main(string[] args)
        {
            Console.WriteLine("enter the message");
            string msg = Console.ReadLine();
            PrintDel del1 = new PrintDel(PrintToConsole);
            PrintDel del2 = new PrintDel(PrintToFile);
            PrintDel multidel = del1 + del2;
            multidel(msg);
        }

        public static void PrintToConsole(string message)
        {
            Console.WriteLine("hello you are in console now " + message);
        }

        public static void PrintToFile(string message)
        {
            FileStream fs = new FileStream("message.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(message);
            sw.Flush();
            fs.Close();
        }
    }
}
