using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMusic.Infrastructure
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<DataBase>
    {
        public DataBase CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBase>();
            optionsBuilder.UseSqlServer(@"Server=tcp:infnet.database.windows.net,1433;Initial Catalog=SocialMusic;Persist Security Info=False;User ID=gvianna;Password=Ervilhag140994;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new DataBase(optionsBuilder.Options);
        }
    }
}
