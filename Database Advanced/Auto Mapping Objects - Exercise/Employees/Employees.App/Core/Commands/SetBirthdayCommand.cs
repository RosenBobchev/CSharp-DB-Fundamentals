namespace Employees.App.Core.Commands
{
    using System;

    using Contracts;

    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeControler employeeService;

        public SetBirthdayCommand(IEmployeeControler employeeService)
        {
            this.employeeService = employeeService;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new ArgumentException("Invalid command!");
            }

            int employeeId = int.Parse(data[0]);
            DateTime birthday = DateTime.ParseExact(data[1], "dd-MM-yyyy", null);

            this.employeeService.SetBirthday(employeeId, birthday);

            Console.WriteLine($"Birthday changed successfully!");
        }
    }
}