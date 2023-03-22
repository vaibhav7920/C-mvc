using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
