﻿namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using Services;

    public class LoginCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;

        public LoginCommand(IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
        }

        public string Execute(params string[] arguments)
        {
            var username = arguments[0];
            var password = arguments[1];

            var user = userSessionService.Login(username, password);

            if (user == null)
            {
                return "Invalid username or password!";
            }

            return $"{username} logged in successfully";
        }
    }
}