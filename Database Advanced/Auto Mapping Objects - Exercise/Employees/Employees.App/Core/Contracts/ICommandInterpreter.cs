namespace Employees.App.Core.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand GetCommand(string commandName);
    }
}