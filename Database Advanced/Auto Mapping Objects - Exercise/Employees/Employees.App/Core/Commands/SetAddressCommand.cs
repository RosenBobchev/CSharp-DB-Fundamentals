namespace Employees.App.Core.Commands
{
    using System;

    using Contracts;

    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeControler employeeService;

        public SetAddressCommand(IEmployeeControler employeeService)
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
            string address = data[1];

            this.employeeService.SetAddress(employeeId, address);

            Console.WriteLine($"Employee with id {employeeId} has new address: {address}");
        }
    }
}