namespace PhotoShare.Services
{
    using Models;
    using Contracts;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using AutoMapper.QueryableExtensions;
    using PhotoShare.Models.Enums;

    public class AlbumService : IAlbumService
    {
        private readonly PhotoShareContext context;

        public AlbumService(PhotoShareContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int id)
            => By<TModel>(a => a.Id == id).SingleOrDefault();

        public TModel ByName<TModel>(string name) 
            => By<TModel>(a => a.Name == name).SingleOrDefault();

        public bool Exists(int id)
            => this.ById<Album>(id) != null;

        public bool Exists(string name)
            => this.ByName<Album>(name) != null;

        public Album Create(int userId, string albumTitle, string BgColor, params string[] tags)
        {
            var backgroundColors = Enum.Parse<Color>(BgColor, true);

            Tag[] tagEntities = context.Tags.Where(t => tags.Contains(t.Name)).ToArray();

            Album album = new Album
            {
                Name = albumTitle,
                BackgroundColor = backgroundColors
            };

            this.context.Albums.Add(album);

            for (int i = 0; i < tagEntities.Count(); i++)
            {
                AlbumTag albumTag = new AlbumTag
                {
                    AlbumId = album.Id,
                    TagId = tagEntities[i].Id
                };
            }

            this.context.SaveChanges();
            return album;
        }

        private IEnumerable<TModel> By<TModel>(Func<Album, bool> predicate) =>
            this.context.Albums
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();
    }
}
