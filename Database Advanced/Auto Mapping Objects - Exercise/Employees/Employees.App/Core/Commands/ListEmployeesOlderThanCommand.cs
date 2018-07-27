namespace Employees.App.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Employees.App.Models;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeControler employeeService;

        public ListEmployeesOlderThanCommand(IEmployeeControler employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(string[] data)
        {
            if(data.Length != 1)
            {
                throw new ArgumentException("Invalid command!");
            }

            int age = int.Parse(data[0]);

            List<EmployeeWithManagerDto> employeesDto = this.employeeService.GetEmployeesOlderThan(age);

            foreach (var employee in employeesDto)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}