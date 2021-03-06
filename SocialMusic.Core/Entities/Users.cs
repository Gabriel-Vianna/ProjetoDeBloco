using System;

namespace SocialMusic.Core
{
    public partial class Application
    {
        public class Users
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string FavotireArtist { get; set; }
            public string FavotireSong { get; set; }
            public string MusicStyle { get; set; }
            public string About { get; set; }
            public string ProfileImage { get; set; }
        }
    }
}
