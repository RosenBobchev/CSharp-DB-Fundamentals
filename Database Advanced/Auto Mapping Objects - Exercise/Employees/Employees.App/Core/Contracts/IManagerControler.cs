namespace Employees.App.Core.Contracts
{
    using Employees.App.Models;

    public interface IManagerControler
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int managerId);
    }
}