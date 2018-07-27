namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using Models;
    using Models.Enums;
    using Services;
    using Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IAlbumService albumService;
        private readonly IAlbumRoleService albumRoleService;
        private readonly IUserSessionService userSessionService;

        public ShareAlbumCommand(IUserService userService, IAlbumService albumService, IAlbumRoleService albumRoleService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.albumService = albumService;
            this.albumRoleService = albumRoleService;
            this.userSessionService = userSessionService;
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permission = data[2];

            var albumExists = albumService.Exists(albumId);
            var userExists = userService.Exists(username);

            if (!albumExists)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }
            else if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            bool isValid = Enum.TryParse(permission, true, out Role role);

            if (!isValid)
            {
                throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
            }

            var userId = userService.ByUsername<User>(username).Id;
            var albumName = albumService.ById<Album>(albumId).Name;

            AlbumRole albumRole = albumRoleService.PublishAlbumRole(albumId, userId, permission);
            
            return $"Username {username} added to album {albumName} ({albumRole.Role.ToString()})";
        }
    }
}