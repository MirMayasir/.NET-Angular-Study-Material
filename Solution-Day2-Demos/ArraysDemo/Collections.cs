using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Collections
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);  
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            
            stack.Pop();
            foreach (var item in stack) { 
                Console.WriteLine(item);
            }

        }
    }
}
