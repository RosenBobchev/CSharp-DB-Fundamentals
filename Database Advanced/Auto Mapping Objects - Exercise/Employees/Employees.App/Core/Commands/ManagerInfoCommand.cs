namespace Employees.App.Core.Commands
{
    using System;

    using Contracts;
    using Employees.App.Models;

    public class ManagerInfoCommand : ICommand
    {
        private readonly IManagerControler managerControler;

        public ManagerInfoCommand(IManagerControler managerControler)
        {
            this.managerControler = managerControler;
        }

        public void Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new ArgumentException("Invalid command!");
            }

            int managerId = int.Parse(data[0]);

            ManagerDto manager = this.managerControler.GetManagerInfo(managerId);

            Console.WriteLine(manager.ToString());
        }
    }
}