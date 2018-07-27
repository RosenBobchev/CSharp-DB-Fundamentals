namespace Employees.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand GetCommand(string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly()
                                       .GetTypes()
                                       .Where(t => typeof(ICommand).IsAssignableFrom(t) && t.Name == commandName + "Command")
                                       .FirstOrDefault();

            var constructor = commandType.GetConstructors().First();

            var parameters = constructor.GetParameters()
                                        .Select(p => serviceProvider.GetService(p.ParameterType))
                                        .ToArray();

            ICommand command = (ICommand)constructor.Invoke(parameters);

            return command;
        }
    }
}