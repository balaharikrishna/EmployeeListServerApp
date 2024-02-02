using EmployeeInfo.Data;
using EmployeeInfo.Modals;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeInfoDbContext Context;
        public EmployeeService(EmployeeInfoDbContext _Context)
        {
            Context = _Context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return await Context.Employees.Where(e => e.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while retrieving employees: {ex.Message}");
                return new List<Employee>();
            }
        }

        public async Task<Employee?> GetEmployeeById(string id)
        {
            Employee? emp = await Context.Employees.FirstOrDefaultAsync(e => e.EmployeeId.Equals(id) && e.IsActive);
            if (emp is not null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AddEmployee(Employee emp)
        {
            await Context.Employees.AddAsync(emp);
            int rowsAffected = await Context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateEmployee(Employee emp)
        {
            Employee? empObj = await GetEmployeeById(emp.EmployeeId);
            if (empObj!.EmployeeId is not null)
            {
                empObj.EmployeeId = emp.EmployeeId;
            }
            else if (empObj!.Name is not null)
            {
                empObj.Name = emp.Name;
            }
            else if (empObj!.Department is not null)
            {
                empObj.Department = emp.Department;
            }
            else if (empObj!.PhoneNumber is not null)
            {
                empObj.PhoneNumber = emp.PhoneNumber;
            }
            Context.Employees.Update(empObj);
            int rowsAffected = await Context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteEmployee(string id)
        {

            Employee? emp = await GetEmployeeById(id);
            emp!.IsActive = false;
            Context.Employees.Update(emp);
            int rowsAffected = await Context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
