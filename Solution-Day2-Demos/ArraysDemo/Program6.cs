using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    internal class Program6
    {
        static int[] num = new int[10] { 3, 6, 7, 0, 0, 0, 0, 0, 0, 0 };

        static int Menu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. insert ");
            Console.WriteLine("2. display");
            Console.WriteLine("3. delete");
            Console.WriteLine("enter choice");
            int ch = byte.Parse(Console.ReadLine());
            return ch;
        }
        static void Main()
        {
            string choice = "y";
            while (choice.ToLower() == "y")
            {
                int ch = Menu();
                switch (ch)
                {
                    case 1:
                        {
                            Console.WriteLine("enter element to insert");
                            int data = Byte.Parse(Console.ReadLine());
                            int pos = InsertElement(data);
                            Console.WriteLine("element inserted at " + pos + " index");
                            break;
                        }
                    case 2:
                        {
                            DisplayElements();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("enter element to delete");
                            int data = byte.Parse(Console.ReadLine());
                            DeleteElement(data);
                            break;
                        }

                }
                Console.WriteLine("Repeat?");
                choice = Console.ReadLine();
            }
        }

        static void DisplayElements()
        {
            foreach (int temp in num)
                Console.WriteLine(temp);
        }
        static int InsertElement(int data)
        {
            int pos = GetPositionOf0();
            int latestPos = 0;
            if (data <= num[0])
            {
                for (int i = pos - 1; i >= 0; i--)
                {
                    num[i + 1] = num[i];
                    latestPos = i;
                }
                num[latestPos] = data;
            }
            else if (data >= num[GetPositionOf0() - 1])
            {
                num[GetPositionOf0()] = data;
                return GetPositionOf0();
            }
            else
            {
                for (int i = 0; i < num.Length; i++)
                {
                    if (data >= num[i] && data < num[i + 1])
                    {
                        for (int j = GetPositionOf0() - 1; j > i; j--)
                        {
                            num[j + 1] = num[j];
                        }
                        num[i + 1] = data;
                        latestPos = i + 1;
                        break;

                    }

                }
            }

            return latestPos;
        }

        static int GetPositionOf0()
        {
            int pos = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == 0)
                {
                    pos = i;
                    break;
                }

            }
            return pos;
        }

        static void DeleteElement(int data)
        {
            int pos = Array.IndexOf(num, data);

            if (pos == -1)
            {
                Console.WriteLine("Element not found.");
                return;
            }

   
            for (int i = pos; i < num.Length - 1; i++)
            {
                num[i] = num[i + 1];
            }

            // Set the last element to 0 (or you could leave it unchanged)
            num[num.Length - 1] = 0;

            Console.WriteLine("Element deleted.");
          
        }


    }
}
