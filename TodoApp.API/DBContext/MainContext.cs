using Microsoft.EntityFrameworkCore;
using TodoApp.API.Models;

namespace TodoApp.API.DBContext
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
