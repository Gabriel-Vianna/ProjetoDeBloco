using System;
using System.Collections.Generic;

namespace SocialMusic.Core
{
    public partial class Application
    {
        private readonly IPostRepository postRepository;
        private readonly IUsersRepository usersRepository;
        public Application(IPostRepository postRepository, IUsersRepository usersRepository)
        {
            this.postRepository = postRepository;
            this.usersRepository = usersRepository;
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

        public void CreateOrUpdateUser(string name, string email, string age, string gender, string country, string state, string city, string favoriteArtist, string favoriteSong, string musicStyle, string about, string profileImage)
        {
            Users userFromDb = usersRepository.Find(email);

            Users createUser = new Users();

            if(profileImage == "")
            {
                profileImage = userFromDb.ProfileImage;
            }

            if(userFromDb == null)
            {
                createUser.Name = name;
                createUser.Email = email;
                createUser.Age = age;
                createUser.Gender = gender;
                createUser.Country = country;
                createUser.State = state;
                createUser.City = city;
                createUser.About = about;
                createUser.FavotireArtist = favoriteArtist;
                createUser.FavotireSong = favoriteSong;
                createUser.MusicStyle = musicStyle;
                createUser.ProfileImage = profileImage;
                usersRepository.Save(createUser);
            }else
            {
                userFromDb.Name = name;
                userFromDb.Age = age;
                userFromDb.Gender = gender;
                userFromDb.Country = country;
                userFromDb.State = state;
                userFromDb.City = city;
                userFromDb.About = about;
                userFromDb.FavotireArtist = favoriteArtist;
                userFromDb.FavotireSong = favoriteSong;
                userFromDb.MusicStyle = musicStyle;
                userFromDb.ProfileImage = profileImage;
                usersRepository.Update(userFromDb);
            }
        }

        public Users getUser(string email)
        {
            Users userFromDb = usersRepository.Find(email);
            return userFromDb;
        }
    }
}
