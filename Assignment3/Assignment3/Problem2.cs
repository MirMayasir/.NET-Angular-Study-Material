using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Problem2
    {
        static void Main(string[] args)
        {
            Console.Write("Enter marks in Maths: ");
            int mathsMarks = Convert.ToByte(Console.ReadLine());

            Console.Write("Enter marks in Physics: ");
            int physicsMarks = Convert.ToByte(Console.ReadLine());

            Console.Write("Enter marks in Chemistry: ");
            int chemistryMarks = Convert.ToByte(Console.ReadLine());

            bool isEligible = CheckEligibility(mathsMarks, physicsMarks, chemistryMarks);

            if (isEligible)
            {
                Console.WriteLine("The candidate is eligible for admission.");
            }
            else
            {
                Console.WriteLine("The candidate is not eligible for admission.");
            }


        }
        static bool CheckEligibility(int maths, int physics, int chemistry)
        {
            int totalMarks = maths + physics + chemistry;

            if (maths >= 65 && physics >= 55 && chemistry >= 50 && totalMarks >= 180)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
