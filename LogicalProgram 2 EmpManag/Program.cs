using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LogicalProgram2
{
    [Serializable]
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string DepartmentID { get; set; }
    }

    [Serializable]
    public class Department
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class EmployeeService
    {
        private List<Employee> Employees = new List<Employee>();
        private List<Department> Departments = new List<Department>();
        private const string EmployeeDataFile = "employees.json";

        public EmployeeService()
        {
            // Load existing data (if any) when the service is initialized
            LoadEmployeeDataFromFile();
        }

        public void AddEmployee(string employeeID, string name, string departmentID)
        {
            if (string.IsNullOrEmpty(employeeID))
                throw new ArgumentException("EmployeeID cannot be null or empty");

            if (string.IsNullOrEmpty(name) || name.Length < 1)
                throw new ArgumentException("Name must contain at least one character");

            if (string.IsNullOrEmpty(departmentID) || !Departments.Any(d => d.DepartmentID == departmentID))
                throw new ArgumentException("Invalid DepartmentID");

            if (Employees.Any(e => e.EmployeeID == employeeID))
                throw new ArgumentException("Duplicate EmployeeID");

            Employee newEmployee = new Employee
            {
                EmployeeID = employeeID,
                Name = name,
                DepartmentID = departmentID
            };

            Employees.Add(newEmployee);
            SaveEmployeeDataToFile();
        }

        public List<Employee> GetEmployeesByDepartment(string departmentID)
        {
            if (string.IsNullOrEmpty(departmentID))
                throw new ArgumentException("DepartmentID cannot be null or empty");

            LoadEmployeeDataFromFile();

            return Employees.Where(e => e.DepartmentID == departmentID).ToList();
        }

        public void SaveEmployeeDataToFile()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(Employees);
                File.WriteAllText(EmployeeDataFile, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving employee data: " + ex.Message);
            }
        }

        public void LoadEmployeeDataFromFile()
        {
            try
            {
                if (File.Exists(EmployeeDataFile))
                {
                    string jsonString = File.ReadAllText(EmployeeDataFile);
                    Employees = JsonSerializer.Deserialize<List<Employee>>(jsonString) ?? new List<Employee>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading employee data: " + ex.Message);
                Employees = new List<Employee>(); // Initialize to an empty list if loading fails
            }
        }

        public void AddDepartment(string departmentID, string departmentName)
        {
            if (string.IsNullOrEmpty(departmentID))
                throw new ArgumentException("DepartmentID cannot be null or empty");

            if (string.IsNullOrEmpty(departmentName) || departmentName.Length < 1)
                throw new ArgumentException("DepartmentName must contain at least one character");

            if (Departments.Any(d => d.DepartmentID == departmentID))
                throw new ArgumentException("Duplicate DepartmentID");

            Department newDepartment = new Department
            {
                DepartmentID = departmentID,
                DepartmentName = departmentName
            };

            Departments.Add(newDepartment);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EmployeeService employeeService = new EmployeeService();

            // Add some departments
            employeeService.AddDepartment("D001", "Human Resources");
            employeeService.AddDepartment("D002", "Engineering");

            // Add some employees
            try
            {
                employeeService.AddEmployee("E001", "John Doe", "D001");
                employeeService.AddEmployee("E002", "Jane Smith", "D002");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error adding employee: " + ex.Message);
            }

            // Retrieve and display employees by department
            var hrEmployees = employeeService.GetEmployeesByDepartment("D001");
            Console.WriteLine("Employees in Human Resources:");
            foreach (var emp in hrEmployees)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.Name}");
            }

            // Simulate program exit and reload data
            employeeService = new EmployeeService();
            var engineeringEmployees = employeeService.GetEmployeesByDepartment("D002");
            Console.WriteLine("Employees in Engineering:");
            foreach (var emp in engineeringEmployees)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.Name}");
            }
        }
    }
}
