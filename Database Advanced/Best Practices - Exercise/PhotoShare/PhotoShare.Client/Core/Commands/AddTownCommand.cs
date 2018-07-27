namespace PhotoShare.Client.Core.Commands
{
    using System;
    
    using Contracts;
    using Services.Contracts;
    using Services;

    public class AddTownCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;
        private readonly ITownService townService;

        public AddTownCommand(IUserSessionService userSessionService, ITownService townService)
        {
            this.userSessionService = userSessionService;
            this.townService = townService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            var townExists = this.townService.Exists(townName);

            if (townExists)
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }
            if (!this.userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var town = this.townService.Add(townName, country);

            return $"Town {townName} was added successfully!";
        }
    }
}