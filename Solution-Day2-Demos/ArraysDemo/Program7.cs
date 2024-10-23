using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Program7
    {
        static void Main(string[] args)
        {
           /* Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(3);
            stack.Push(4);
            stack.Pop();

            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }*/

           /* List<string> list = new List<string>();
            list.Add("A");
            list.Add("4");
            list.Add("n");

            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
           */

           Queue<float> queue = new Queue<float>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(9);

            queue.Dequeue();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

        }
    }


}
