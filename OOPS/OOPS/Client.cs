using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class Client
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("wipro");
            emp1.Eid = "100";
            emp1.Ename = "mayasir";
            emp1.Esalary = 123456;
            emp1.Dob = "25-07-2002";
           
            emp1.PrintDetails();
            /*Console.WriteLine("employee one details");
            emp1.GetDetails();
            emp1.PrintDetails();

            Employee emp2 = new Employee();
            Console.WriteLine("employee 2 details");
            emp2.GetDetails();
            emp2.PrintDetails();

            Employee emp3 = new Employee();
            Console.WriteLine("employee one details");
            emp3.GetDetails();
            emp3.PrintDetails();*/


        }
    }
}
