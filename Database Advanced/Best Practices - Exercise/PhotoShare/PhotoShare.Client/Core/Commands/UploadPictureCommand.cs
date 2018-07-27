namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;
    using PhotoShare.Services;

    public class UploadPictureCommand : ICommand
    {
        private readonly IPictureService pictureService;
        private readonly IAlbumService albumService;
        private readonly IUserSessionService userSessionService;

        public UploadPictureCommand(IPictureService pictureService, IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.pictureService = pictureService;
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string pictureTitle = data[1];
            string path = data[2];

            var albumExists = this.albumService.Exists(albumName);

            if (!albumExists)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var albumId = this.albumService.ByName<AlbumDto>(albumName).Id;

            var picture = this.pictureService.Create(albumId, pictureTitle, path);

            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}