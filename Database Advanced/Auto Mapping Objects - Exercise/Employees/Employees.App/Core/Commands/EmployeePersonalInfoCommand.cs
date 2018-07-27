namespace Employees.App.Core.Commands
{
    using System;
    using System.Globalization;
    using Contracts;
    using Employees.App.Models;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeControler employeeService;

        public EmployeePersonalInfoCommand(IEmployeeControler employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new ArgumentException("Invalid command!");
            }

            int employeeId = int.Parse(data[0]);

            EmployeePersonalInfoDto employeeInfo = this.employeeService.GetEmployeePersonalInfo(employeeId);

            string result = $"ID: {employeeInfo.Id} - {employeeInfo.FirstName} {employeeInfo.LastName} - ${employeeInfo.Salary:f2}" +
             Environment.NewLine + $"Birthday: {employeeInfo.Birthday?.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}" +
             Environment.NewLine + $"Address: {employeeInfo.Address}";

            Console.WriteLine(result);
        }
    }
}