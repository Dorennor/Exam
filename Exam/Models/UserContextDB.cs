using Microsoft.EntityFrameworkCore;

namespace Exam.Models
{
    public sealed class UserContextDB : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContextDB(DbContextOptions<UserContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
