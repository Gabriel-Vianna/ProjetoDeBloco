using System;

namespace SocialMusic.Core
{
    public partial class Application
    {
        public class Post
        {
            public Guid Id { get; internal set; }
            public string Title { get; internal set; }
            public string Text { get; internal set; }
            public string Image { get; internal set; }
            public string Author { get; internal set; }
            public DateTime CreatedAt { get; internal set; }
        }
    }
}
