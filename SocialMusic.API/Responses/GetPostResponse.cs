using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMusic.API.Responses
{
    public class GetPostResponse
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
