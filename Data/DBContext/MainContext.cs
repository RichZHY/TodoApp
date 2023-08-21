using Microsoft.EntityFrameworkCore;
using TodoApp.API.Models;

namespace TodoApp.API.DataAccess.DBContext
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
