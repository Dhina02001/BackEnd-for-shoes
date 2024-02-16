using Microsoft.EntityFrameworkCore;

namespace EcomwebProjNew.Models
{
    public class UserLoginContext : DbContext
    {
        public UserLoginContext(DbContextOptions<UserLoginContext> options) : base(options)
        {

        }

        // DbSet representing your entity class, not the context itself
        public DbSet<UsersLogin> UserLogins { get; set; }
    }
}