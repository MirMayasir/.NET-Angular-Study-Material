using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MySQLdemo.Model;

namespace MySQLdemo
{
    internal class Program
    {
        public static WiprodbContext contect = new WiprodbContext();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /*GetDetails();*/
            /*AddEmploye();*/
            /*Console.WriteLine("enter the empid");
            int id = Convert.ToInt32(Console.ReadLine());*/
            /*FindById(id);*/
            /* DeleteEmp(id);*/
            Employee employee = new Employee();
            Console.WriteLine("enter the id");
            int eid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the name");
            string ename = Console.ReadLine();
            Console.WriteLine("enter the salary");
            string ssalary = Console.ReadLine();
            Employee emp = new Employee
            {
                Eid = eid,
                Esalary = ssalary,
                Ename = ename
            };

            UpdateDetails(eid, emp);


        }

        private static void GetDetails()
        {
            foreach(var item in contect.Employees)
            {
                Console.WriteLine(item.Eid + " " + item.Ename + " " + item.Esalary);
            }
        }

        private static void AddEmploye()
        {
            Employee employee = new Employee();
            Console.WriteLine("enter the id");
            employee.Eid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the name");
            employee.Ename = Console.ReadLine();
            Console.WriteLine("enter the salary");
            employee.Esalary = Console.ReadLine();

            contect.Employees.Add(employee);
            contect.SaveChanges();
            Console.WriteLine("added successfully");
        }

        private static void FindById(int empid)
        {
            Employee e = contect.Employees.FirstOrDefault(x=> x.Eid == empid);
            if (e != null)
            {
                Console.WriteLine(e.Eid + " " + e.Ename + " " + e.Esalary);
            }
            else
            {
                Console.WriteLine("could not find");
            }
        }

        private static void DeleteEmp(int eid)
        {
            Employee e = contect.Employees.FirstOrDefault(x=> x.Eid==eid);
            contect.Employees.Remove(e);
            contect.SaveChanges();
            Console.WriteLine("entry deleted");
        }

        private static void UpdateDetails(int eid, Employee e)
        {
            Employee emp = contect.Employees.FirstOrDefault(x=> x.Eid==eid);
            if (emp != null)
            {
                emp.Ename = e.Ename;
                emp.Esalary = e.Esalary;
                contect.SaveChanges();
                Console.WriteLine("editing successfull");
            }
            else
            {
                Console.WriteLine("could not found course");
            }
        }
    }
}
