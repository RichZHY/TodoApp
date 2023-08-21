using Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.API.DataAccess.DBContext;
using TodoApp.API.Models;

namespace Data.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MainContext context) : base(context) { }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await FindAll().OrderBy(x => x.Id).ToArrayAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}
