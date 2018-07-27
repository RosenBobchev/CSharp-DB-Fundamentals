namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Dtos;
    using Services;
    using Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ITownService townService;
        private readonly IUserSessionService userSessionService;

        public ModifyUserCommand(IUserService userService, ITownService townService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.townService = townService;
            this.userSessionService = userSessionService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string property = data[1];
            string value = data[2];

            var userExists = userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }
            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            if (property == "Password")
            {
                SetPassword(userId, value);
            }
            else if (property == "BornTown")
            {
                SetBornTown(userId, value);
            }
            else if (property == "CurrentTown")
            {
                SetCurrentTown(userId, value);
            }
            else
            {
                throw new ArgumentException($"Property {property} not supported!");
            }

            return $"User {username} {property} is {value}";
        }

        private void SetCurrentTown(int userId, string townName)
        {
            var townExist = this.townService.Exists(townName);

            if (!townExist)
            {
                throw new ArgumentException($"Value {townName} not valid.\nTown {townName} not found!");
            }

            var townId = this.townService.ByName<TownDto>(townName).Id;

            this.userService.SetCurrentTown(userId, townId);
        }

        private void SetBornTown(int userId, string townName)
        {
            var townExist = this.townService.Exists(townName);

            if (!townExist)
            {
                throw new ArgumentException($"Value {townName} not valid.\nTown {townName} not found!");
            }

            var townId = this.townService.ByName<TownDto>(townName).Id;

            this.userService.SetBornTown(userId, townId);
        }

        private void SetPassword(int userId, string password)
        {
            var isValidLowerCasePassword = password.Any(x => char.IsLower(x));
            var isValidDigitCasePassword = password.Any(x => char.IsDigit(x));

            if (!isValidDigitCasePassword || !isValidLowerCasePassword)
            {
                throw new ArgumentException($"Value {password} not valid.\nInvalid Password!");
            }

            this.userService.ChangePassword(userId, password);
        }
    }
}