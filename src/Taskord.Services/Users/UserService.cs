﻿namespace Taskord.Services.Users
{
    using System.Collections.Generic;
    using Taskord.Data;
    using Taskord.Services.Users.Models;

    public class UserService : IUserService
    {
        private readonly TaskordDbContext data;

        public UserService(TaskordDbContext data)
        {
            this.data = data;
        }


        public IEnumerable<UserListServiceModel> GetTeamMembersList(string teamId)
        {
            var members = data.Users
                .Where(x => x.UserTeams.Any(t => t.Team.Id == teamId))
                .Select(x => new UserListServiceModel { Id = x.Id, Name = x.UserName, ImagePath = x.ImagePath })
                .ToList();

            return members;
        }

        public IEnumerable<UserListServiceModel> GetUserFriendRequests(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserListServiceModel> GetUserFriendsList(string userId)
        {
            var friends = data.Users
                .FirstOrDefault(x => x.UserName == userId)
                .Friends
                .Select(x => new UserListServiceModel { Id = x.Id, Name = x.UserName, ImagePath = x.ImagePath })
                .ToList();

            return friends;
        }

        public IEnumerable<UserListServiceModel> GetUserPendingRequests(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserListServiceModel> GetUsersBySearchTerm(string searchTerm)
        {
            var users = data.Users
                .Where(x => x.UserName.Contains(searchTerm))
                .Select(x => new UserListServiceModel { Id = x.Id, Name = x.UserName, ImagePath = x.ImagePath })
                .ToList();

            return users;
        }
    }
}
