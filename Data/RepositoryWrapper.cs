using Data.IRepositories;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.API.DataAccess.DBContext;

namespace Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MainContext _context;
        private IEmployeeRepository _employee;
        public RepositoryWrapper(MainContext context)
        {
            _context = context;
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_context);
                }
                return _employee;
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
