namespace Employees.App.Core.Commands
{
    using System;
    using System.Threading;
    using Contracts;

    public class ExitCommand : ICommand
    {
        public void Execute(string[] data)
        {
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"The program will shutdown in {i}");
                Thread.Sleep(1000);
            }

            Environment.Exit(0);
        }
    }
}