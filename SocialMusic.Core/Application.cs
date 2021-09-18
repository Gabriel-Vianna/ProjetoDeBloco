using System;
using System.Collections.Generic;

namespace SocialMusic.Core
{
    public partial class Application
    {
        private readonly IPostRepository postRepository;
        public Application(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public void PublicPost(string title, string text, string image, string author, DateTime CreatedAt)
        {
            var post = new Post();
            post.Id = Guid.NewGuid();
            post.Title = title;
            post.Text = text;
            post.Image = image;
            post.Author = author;
            post.CreatedAt = CreatedAt;

            postRepository.Save(post);
        }

        public IEnumerable<Post> ListPosts()
        {
            return postRepository.GetAll();
        }
    }
}
