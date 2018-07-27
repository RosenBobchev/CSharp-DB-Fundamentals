namespace Employees.App.Core.Commands
{
    using System;

    using Contracts;
    using Employees.App.Models;

    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeControler employeeService;

        public AddEmployeeCommand(IEmployeeControler employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 3)
            {
                throw new ArgumentException("Invalid command!");
            }

            string firstName = data[0];
            string lastName = data[1];
            decimal salary = decimal.Parse(data[2]);

            EmployeeDto employee = new EmployeeDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeService.AddEmployee(employee);

            Console.WriteLine($"Successfull added employee {employee.FirstName} {employee.LastName}");
        }
    }
}