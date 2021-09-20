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

            Users createOrUpdateUser = new Users();


            if(userFromDb == null)
            {
                createOrUpdateUser.Name = name;
                createOrUpdateUser.Email = email;
                createOrUpdateUser.Age = age;
                createOrUpdateUser.Gender = gender;
                createOrUpdateUser.Country = country;
                createOrUpdateUser.State = state;
                createOrUpdateUser.City = city;
                createOrUpdateUser.About = about;
                createOrUpdateUser.FavotireArtist = favoriteArtist;
                createOrUpdateUser.FavotireSong = favoriteSong;
                createOrUpdateUser.MusicStyle = musicStyle;
                createOrUpdateUser.ProfileImage = profileImage;
                usersRepository.Save(createOrUpdateUser);
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
