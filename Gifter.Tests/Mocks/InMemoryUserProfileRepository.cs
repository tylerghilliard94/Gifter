using System;
using System.Collections.Generic;
using System.Linq;
using Gifter.Models;
using Gifter.Repositories;

namespace Gifter.Tests.Mocks
{
    class InMemoryUserProfileRepository : IUserProfileRepository
    {
        private readonly List<UserProfile> _data;

        public List<UserProfile> InternalData
        {
            get
            {
                return _data;
            }
        }

        public InMemoryUserProfileRepository(List<UserProfile> startingData)
        {
            _data = startingData;
        }

        public void Add(UserProfile userProfile)
        {
            var lastUser = _data.Last();
            userProfile.Id = lastUser.Id + 1;
            _data.Add(userProfile);
        }

        public void Delete(int id)
        {
            var userTodelete = _data.FirstOrDefault(p => p.Id == id);
            if (userTodelete == null)
            {
                return;
            }

            _data.Remove(userTodelete);
        }

        public List<UserProfile> GetAll()
        {
            return _data;
        }
        public List<UserProfile> GetAllByUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }
        public UserProfile GetByFirebaseId(string id)
        {
            return _data.FirstOrDefault(p => p.FirebaseUserId == id);
        }

        public UserProfile GetByIdWithPosts(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserProfile user)
        {
            var currentUser = _data.FirstOrDefault(p => p.Id == user.Id);
            if (currentUser == null)
            {
                return;
            }

            currentUser.Name = user.Name;
            currentUser.Email = user.Email;
            currentUser.DateCreated = user.DateCreated;
            currentUser.ImageUrl = user.ImageUrl;
            currentUser.FirebaseUserId = user.FirebaseUserId;
        }

        public List<Post> Search(string criterion, bool sortDescending)
        {
            throw new NotImplementedException();
        }
        public List<Post> SearchbyDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllWithComments()
        {
            throw new NotImplementedException();
        }

        public Post GetByIdWithComments(int id)
        {
            throw new NotImplementedException();
        }
    }
}