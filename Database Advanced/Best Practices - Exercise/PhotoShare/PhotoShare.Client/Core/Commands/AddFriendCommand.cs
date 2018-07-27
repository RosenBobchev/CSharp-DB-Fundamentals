namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Dtos;
    using Services;
    using Services.Contracts;

    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;

        public AddFriendCommand(IUserService userService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            var username = data[0];
            var friendUsername = data[1];

            var userExists = this.userService.Exists(username);
            var friendExists = this.userService.Exists(friendUsername);

            if (!userExists)
            {
                throw new ArgumentException($"{username} not found!");
            }
            if (!friendExists)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }
            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendUsername);

            bool isRequestSendFromUser = user.Friends.Any(x => x.Username == friend.Username);
            bool isRequestSendFromFriend = friend.Friends.Any(x => x.Username == user.Username);

            if (isRequestSendFromUser && isRequestSendFromFriend)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }
            else if (isRequestSendFromUser && !isRequestSendFromFriend)
            {
                throw new InvalidOperationException("Request is already send!");
            }
            else if (!isRequestSendFromUser && isRequestSendFromFriend)
            {
                throw new InvalidOperationException("Request is already send!");
            }
            
            this.userService.AddFriend(user.Id, friend.Id);

            return $"{user.Username} added to {friend.Username}";
        }
    }
}