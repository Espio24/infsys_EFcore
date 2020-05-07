using Microsoft.EntityFrameworkCore;

namespace MySQLApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tester> Tester { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}