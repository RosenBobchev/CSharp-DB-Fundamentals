namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using Dtos;
    using Utilities;
    using Services;
    using Services.Contracts;

    public class AddTagToCommand : ICommand
    {
        private readonly IAlbumTagService albumTagService;
        private readonly ITagService tagService;
        private readonly IAlbumService albumService;
        private readonly IUserSessionService userSessionService;

        public AddTagToCommand(IAlbumTagService albumTagService, ITagService tagService, IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.albumTagService = albumTagService;
            this.albumService = albumService;
            this.tagService = tagService;
            this.userSessionService = userSessionService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] args)
        {
            string albumName = args[0];
            string tagName = args[1].ValidateOrTransform();
            
            var albumExists = this.albumService.Exists(albumName);
            var tagExists = this.tagService.Exists(tagName);
            
            if (!albumExists)
            {
                throw new ArgumentException($"Album {albumName} do not exists!");
            }

            if (!tagExists)
            {
                throw new ArgumentException($"Tag {tagName} do not exists!");
            }
            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var albumId = this.albumService.ByName<AlbumDto>(albumName).Id;
            var tagId = this.tagService.ByName<TagDto>(tagName).Id;

            this.albumTagService.AddTagTo(albumId, tagId);

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}