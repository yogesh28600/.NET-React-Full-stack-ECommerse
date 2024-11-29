using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Context;
public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
}