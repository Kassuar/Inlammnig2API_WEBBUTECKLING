using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Inlammnig2API_WEBBUTECKLING.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}


    
