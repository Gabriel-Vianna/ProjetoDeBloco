using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialMusic.Core.Application;

namespace SocialMusic.Infrastructure
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions options) : base(options)
        {

        }

        //private IConfiguration configuration;

        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(configuration.GetConnectionString("SocialMusicDb"));
        public DbSet<Post> Post { get; set;}
        public DbSet<Users> Users { get; set; } 
    }
}
