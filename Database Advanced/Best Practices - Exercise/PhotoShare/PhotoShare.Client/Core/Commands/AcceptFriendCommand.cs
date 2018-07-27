namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Dtos;
    using Services;
    using Services.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;

        public AcceptFriendCommand(IUserService userService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // AcceptFriend <username1> <username2>
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
            else if (!friendExists)
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
                throw new InvalidOperationException($"{user.Username} is already a friend to {friend.Username}");
            }

            else if (!isRequestSendFromUser && !isRequestSendFromFriend)
            {
                throw new InvalidOperationException($"{user.Username} has not added {friend.Username} as a friend");
            }

            userService.AcceptFriend(user.Id, friend.Id);

            return $"{user.Username} accepted {friend.Username} as a friend";
        }
    }
}