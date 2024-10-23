using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class Employee
    {
        string eid;
        string ename;
        int esalary;
        string dob;

        public string Eid{  get; set; }
        public string Ename { get; set; }
        public int Esalary { get; set; }
        public string Dob { get; set; }

        public string Cname { get; }


        /*public string Eid
        {
            get
            {
                return eid;
            }
            set {
                
                eid = value;
            }
        }*/

        public Employee(string CompanyName)
        {
            Cname = CompanyName;
        }

        public Employee(string name, int esalary, string dob)
        {
            ename= name;
            this.esalary = esalary;
            this.dob = dob;

        }

        public void  GetDetails()
        {
           Console.WriteLine("enter the employee id");
            eid = Console.ReadLine();

            Console.WriteLine("enter the employee name");
            ename = Console.ReadLine();

            Console.WriteLine("enter the employee salary");
            esalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter the employee dob");
            dob = Console.ReadLine();
        }

        public void PrintDetails()
        {
            Console.WriteLine($"the employee name is {Ename}");
            Console.WriteLine($"the employee id is {Eid}");
            Console.WriteLine($"the employee salary is {Esalary}");
            Console.WriteLine($"the employee dob is {Dob}");
            Console.WriteLine($"the company name is {Cname}");
        }
    }
}
