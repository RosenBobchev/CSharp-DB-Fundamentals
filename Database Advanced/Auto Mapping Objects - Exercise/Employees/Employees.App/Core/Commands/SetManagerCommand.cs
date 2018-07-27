namespace Employees.App.Core.Commands
{
    using System;

    using Contracts;

    public class SetManagerCommand : ICommand
    {
        private readonly IManagerControler managerControler;

        public SetManagerCommand(IManagerControler managerControler)
        {
            this.managerControler = managerControler;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new ArgumentException("Invalid command!");
            }

            int employeeId = int.Parse(data[0]);
            int managerId = int.Parse(data[1]);

            this.managerControler.SetManager(employeeId, managerId);

            Console.WriteLine($"Manager changed successfully!");
        }
    }
}