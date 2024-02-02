using EmployeeInfo.Modals;

namespace EmployeeInfo.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(string id);

        Task<bool> AddEmployee(Employee emp);

        Task<bool> UpdateEmployee(Employee emp);

        Task<bool> DeleteEmployee(string id);
    }
}
