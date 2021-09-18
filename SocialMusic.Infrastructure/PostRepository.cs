using System;
using System.Collections.Generic;
using System.Linq;
using SocialMusic.Core;
using static SocialMusic.Core.Application;

namespace SocialMusic.Infrastructure
{
    public class PostRepository : IPostRepository
    {
        public PostRepository(DataBase dataBase)
        {
            DataBase = dataBase;
        }

        public DataBase DataBase { get; }

        public List<Post> GetAll()
        {
            List<Post> posts = DataBase.Post.ToList();
            return posts;
        }

        public void Save(Post post)
        {
            DataBase.Post.Add(post);
            DataBase.SaveChanges();
        }
    }
}
