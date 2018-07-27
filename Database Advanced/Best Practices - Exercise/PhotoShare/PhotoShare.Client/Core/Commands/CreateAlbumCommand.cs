namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Dtos;
    using Utilities;
    using Models.Enums;
    using Services.Contracts;
    using Services;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;
        private readonly IUserSessionService userSessionService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService, IUserSessionService userSessionService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
            this.userSessionService = userSessionService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string backgroundColor = data[2];
            var tags = data.Skip(3).Select(t => t.ValidateOrTransform()).ToArray();

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            
            var albumExists = this.albumService.Exists(albumTitle);

            if (albumExists)
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            var isValidColor = Enum.TryParse(backgroundColor, true, out Color result);

            if (!isValidColor)
            {
                throw new ArgumentException($"Color {backgroundColor} not found!");
            }
            
            for (int i = 0; i < tags.Length; i++)
            {
                var currentTag = this.tagService.Exists(tags[i]);
                
                if (!currentTag)
                {
                    throw new ArgumentException("Invalid tags!");
                }
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            this.albumService.Create(userId, albumTitle, backgroundColor, tags);

            return $"Album {albumTitle} successfully created!";
        }
    }
}