using Microsoft.EntityFrameworkCore;
using MySQLwebAPI.Model;
namespace MySQLwebAPI.Repositery
{
    public class EmployeeRepo : IEmployeRepo<Employee>
    {
        private readonly WiprodbContext _context;

        public EmployeeRepo(WiprodbContext context)
        {
            _context = context;
        }

        public void AddEmp(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChangesAsync();
        }

        public void DeleteEmp(int employeeId)
        {
            Employee e = _context.Employees.Find(employeeId);
            _context.Employees.Remove(e);
            _context.SaveChanges();
        }

        public void EditEmp(int employeeId, Employee e)
        {
            _context.Employees.Update(e);
            _context.SaveChangesAsync();
        }

        public List<Employee> getAll()
        {
            return _context.Employees.ToList();
        }


        public Employee getEmpById(int id)
        {
            var a = _context.Employees.Where(x => x.Eid == id).SingleOrDefault();
            return a;
        }
    }
}
