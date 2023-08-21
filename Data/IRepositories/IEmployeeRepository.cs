using TodoApp.API.Models;

namespace Data.IRepositories
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetEmployees();
        void UpdateEmployee(Employee employee);
    }
}