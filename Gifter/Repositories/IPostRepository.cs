﻿using Gifter.Models;
using System;
using System.Collections.Generic;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        List<Post> GetAllByUser(int id);
        List<Post> GetAllWithComments();
        Post GetById(int id);
        Post GetByIdWithComments(int id);
        void Update(Post post);
        List<Post> Search(string criterion, bool sortDescending);

        List<Post> SearchbyDate(DateTime since);
    }
}