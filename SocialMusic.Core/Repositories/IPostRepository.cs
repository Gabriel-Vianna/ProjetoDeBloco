using System.Collections.Generic;

namespace SocialMusic.Core
{
    public partial class Application
    {
        public interface IPostRepository
        {
            void Save(Post post);
            List<Post> GetAll();
        }
    }
}
