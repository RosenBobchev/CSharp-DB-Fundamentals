namespace Employees.Services
{
    using Employees.Data;
    using Employees.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly EmployeesContext employeesContext;

        public DbInitializerService(EmployeesContext employeesContex)
        {
            this.employeesContext = employeesContex;
        }

        public void Initializer()
        {
            this.employeesContext.Database.Migrate();
        }
    }
}