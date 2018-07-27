namespace Employees.App.Core.Commands
{
    using System;

    using Contracts;
    using Employees.App.Models;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeControler employeeService;

        public EmployeeInfoCommand(IEmployeeControler employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new ArgumentException("Invalid Command!");
            }

            int employeeId = int.Parse(data[0]);

            EmployeeDto employee = this.employeeService.GetEmployeeInfo(employeeId);

            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with id {employeeId} not found!");
            }

            Console.WriteLine(employee.ToString());
        }
    }
}