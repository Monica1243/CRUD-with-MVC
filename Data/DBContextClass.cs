using Microsoft.EntityFrameworkCore;
using Sample.Models.Domain;
namespace Sample.Controllers.Data
{
    public class DBContextClass : DbContext
    {
        public DBContextClass(DbContextOptions options) : base(options)
        {
        }

        //Properties are used to access the tables that entity framework core will create in the db
        public DbSet<Employee> Employees { get; set; }
    }
}
