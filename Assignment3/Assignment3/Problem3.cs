using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Problem3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the name of the customer");
            string customerName = Console.ReadLine();

            Console.WriteLine("enter the customer ID");
            string customerId = Console.ReadLine();

            Console.WriteLine("enter the units consumed");
            int unitsConsumed = Convert.ToInt32(Console.ReadLine());

            double billAmount = CalculateBill(unitsConsumed);
            if (billAmount > 400)
            {
                billAmount += billAmount * 0.15; 
            }

            if (billAmount < 100)
            {
                billAmount = 100;
            }

            Console.WriteLine("\nElectricity Bill");
            Console.WriteLine("----------------");
            Console.WriteLine("Customer ID: " + customerId);
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Units Consumed: " + unitsConsumed);
            Console.WriteLine("Total Amount to Pay: $" + billAmount.ToString("0.00"));
        }
        static double CalculateBill(int units)
        {
            double amount = 0;

            if (units <= 199)
            {
                amount = units * 1.20;
            }
            else if (units >= 200 && units < 400)
            {
                amount = units * 1.50;
            }
            else if (units >= 400 && units < 600)
            {
                amount = units * 1.80;
            }
            else if (units >= 600)
            {
                amount = units * 2.00;
            }

            return amount;
        }
    }
}
