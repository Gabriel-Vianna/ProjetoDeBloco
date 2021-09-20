using System;

namespace SocialMusic.Core
{
    public partial class Application
    {
        public class Post
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Text { get; set; }
            public string Image { get; set; }
            public string Author { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
