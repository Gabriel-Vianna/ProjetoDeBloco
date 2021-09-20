using System.Collections.Generic;

namespace SocialMusic.Core
{
    public partial class Application
    {
        public interface IUsersRepository
        {
            void Save(Users user);
            Users Find(string email);
            void Update(Users user);
            List<Users> GetAll();
        }
    }
}
