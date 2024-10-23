using MySQLwebAPI.Model;

namespace MySQLwebAPI.Services
{
    public interface IEmployeeService<Employee>
    {
        List<Employee> getAll();
        void AddEmp(Employee employee);
        Employee getEmpById(int id);

        void EditEmp(int employeeId, Employee e);

        void DeleteEmp(int employeeId);

        void print();
    }
}
