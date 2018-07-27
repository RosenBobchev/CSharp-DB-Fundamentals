namespace Employees.Data
{
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeesContext : DbContext
    {
        public EmployeesContext()
        {}

        public EmployeesContext(DbContextOptions options)
            : base(options)
        {}

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Manager)
                        .WithMany(m => m.ManagerEmployees)
                        .HasForeignKey(e => e.ManagerId);
        }
    }
}