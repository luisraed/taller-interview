using Microsoft.EntityFrameworkCore;
using UsersApp.Data.Entities;

namespace UsersApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "user1", IsAdmin = true },
                new User { Id = 2, UserName = "user2", IsAdmin = true });
        }

        public DbSet<User> Users { get; set; }
    }
}
