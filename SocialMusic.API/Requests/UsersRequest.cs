using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMusic.API.Requests
{
    public class UsersRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FavoriteArtist { get; set; }
        public string FavoriteSong { get; set; }
        public string MusicStyle { get; set; }
        public string About { get; set; }
        public string ProfileImage { get; set; }
    }
}
