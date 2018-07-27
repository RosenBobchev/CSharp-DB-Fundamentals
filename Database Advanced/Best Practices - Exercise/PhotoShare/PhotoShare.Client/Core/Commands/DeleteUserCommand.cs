namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;
    using Services;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;
        private readonly IUserService userService;

        public DeleteUserCommand(IUserSessionService userSessionService, IUserService userService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.userService.Delete(username);

            return $"User {username} was deleted from the database!";
        }
    }
}