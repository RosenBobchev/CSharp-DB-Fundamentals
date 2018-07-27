namespace Employees.App.Core.Contracts
{
    public interface ICommand
    {
        void Execute(string[] data);
    }
}