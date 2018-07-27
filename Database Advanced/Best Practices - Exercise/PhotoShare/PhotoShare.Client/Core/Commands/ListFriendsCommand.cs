namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Text;

    using Contracts;
    using Services.Contracts;

    public class ListFriendsCommand : ICommand
    {
        private readonly IUserService userService;

        public ListFriendsCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            string username = args[0];

            var userExists = userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var friendsUsername = userService.GetAllFriends(username);

            if (friendsUsername.Length == 0)
            {
                return "No friends for this user. :(";
            }

            var sb = new StringBuilder();
            sb.AppendLine("Friends:");

            foreach (var friend in friendsUsername)
            {
                sb.AppendLine($"-{friend}");
            }

            return sb.ToString().Trim();
        }
    }
}