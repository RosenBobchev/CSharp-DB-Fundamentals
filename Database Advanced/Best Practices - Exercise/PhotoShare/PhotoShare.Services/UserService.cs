﻿namespace PhotoShare.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    using Models;
    using Data;
    using Services.Contracts;

    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly PhotoShareContext context;

        public UserService(PhotoShareContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TModel ById<TModel>(int id)
            => By<TModel>(u => u.Id == id).SingleOrDefault();

        public TModel ByUsername<TModel>(string username)
            => By<TModel>(u => u.Username == username).SingleOrDefault();

        public bool Exists(int id)
            => this.ById<User>(id) != null;

        public bool Exists(string name)
            => this.ByUsername<User>(name) != null;

        public void ChangePassword(int userId, string password)
        {
            var user = this.ById<User>(userId);

            user.Password = password;

            context.SaveChanges();
        }

        public void Delete(string username)
        {
            var user = this.ByUsername<User>(username);

            user.IsDeleted = true;

            context.SaveChanges();
        }

        public User Register(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false
            };

            this.context.Users.Add(user);

            this.context.SaveChanges();

            return user;
        }

        public Friendship AcceptFriend(int userId, int friendId)
        {
            var friendship = new Friendship
            {
                UserId = userId,
                FriendId = friendId
            };

            this.context.Friendships.Add(friendship);

            this.context.SaveChanges();

            return friendship;
        }

        public Friendship AddFriend(int userId, int friendId)
        {
            var friendship = new Friendship
            {
                UserId = userId,
                FriendId = friendId
            };

            this.context.Friendships.Add(friendship);

            this.context.SaveChanges();

            return friendship;
        }

        public string[] GetAllFriends(string username)
        {
            var friendsUsername = context.Friendships
                .Include(f => f.User)
                .Include(f => f.Friend)
                .Where(u => u.User.Username == username)
                .Select(f => f.Friend.Username)
                .OrderBy(f => f)
                .ToArray();

            return friendsUsername;
        }

        public void SetBornTown(int userId, int townId)
        {
            var user = this.ById<User>(userId);

            user.BornTownId = townId;

            this.context.SaveChanges();
        }

        public void SetCurrentTown(int userId, int townId)
        {
            var user = this.ById<User>(userId);

            user.CurrentTownId = townId;

            this.context.SaveChanges();
        }

        public TModel ByUsernameAndPassword<TModel>(string username, string password)
        {
            var user = context.Users
                .Where(u => u.Username == username && u.Password == password)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            return user;
        }
        

        private IEnumerable<TModel> By<TModel>(Func<User, bool> predicate) =>
            this.context.Users
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();
    }
}