namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Threading;

    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] data)
        {
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"Program will shutdown in {i}");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);
            return "Bye-bye!";
        }
    }
}