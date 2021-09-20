using System;
using System.Collections.Generic;
using System.Linq;
using SocialMusic.Core;
using static SocialMusic.Core.Application;

namespace SocialMusic.Infrastructure
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository(DataBase dataBase)
        {
            DataBase = dataBase;
        }

        public DataBase DataBase { get; }

        public List<Users> GetAll()
        {
            List<Users> users = DataBase.Users.ToList();
            return users;
        }

        public void Save(Users user)
        {
            DataBase.Users.Add(user);
            DataBase.SaveChanges();
        }

        public Users Find(string email)
        {
            Users user = (from x in DataBase.Users
                           where x.Email == email
                           select x).FirstOrDefault();
            return user;
        }

        public void Update(Users user)
        {
            DataBase.Users.Update(user);
            DataBase.SaveChanges();
        }
    }
}
