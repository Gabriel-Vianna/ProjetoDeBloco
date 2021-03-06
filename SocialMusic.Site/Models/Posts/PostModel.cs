using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMusic.Site.Models.Posts
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
