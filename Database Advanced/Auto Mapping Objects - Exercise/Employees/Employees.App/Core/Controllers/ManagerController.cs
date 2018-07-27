namespace Employees.App.Core.Controllers
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    using Contracts;
    using Models;
    using Employees.Data;

    public class ManagerControler : IManagerControler
    {
        EmployeesContext context;

        public ManagerControler(EmployeesContext context)
        {
            this.context = context;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);
            employee.ManagerId = managerId;

            context.SaveChanges();
        }

        public ManagerDto GetManagerInfo(int managerId)
        {
            var managerDto = context.Employees
                             .Where(e => e.Id == managerId)
                             .ProjectTo<ManagerDto>().SingleOrDefault();

            return managerDto;
        }
    }
}