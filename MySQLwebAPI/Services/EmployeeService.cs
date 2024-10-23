using MySQLwebAPI.Model;
using MySQLwebAPI.Repositery;

namespace MySQLwebAPI.Services
{
    public class EmployeeService : IEmployeeService<Employee>
    {
        private readonly IEmployeRepo<Employee> _repo;
        public void AddEmp(Employee employee)
        {
            _repo.AddEmp(employee);
        }

        public void DeleteEmp(int employeeId)
        {
            _repo.DeleteEmp(employeeId);
        }

        public void EditEmp(int employeeId, Employee e)
        {
            _repo.EditEmp(employeeId, e);
        }

        public List<Employee> getAll()
        {
            return _repo.getAll();
        }

        public Employee getEmpById(int id)
        {
            return _repo.getEmpById(id);
        }

        public void print()
        {
            //anything
        }
    }
}
