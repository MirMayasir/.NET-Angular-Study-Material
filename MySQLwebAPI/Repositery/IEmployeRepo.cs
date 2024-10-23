using MySQLwebAPI.Model;

namespace MySQLwebAPI.Repositery
{
    public interface IEmployeRepo<Employee>
    {
        List<Employee> getAll();
        void AddEmp(Employee employee);
        Employee getEmpById(int id);

        void EditEmp(int  employeeId, Employee e);

        void DeleteEmp(int employeeId);


    }
}
