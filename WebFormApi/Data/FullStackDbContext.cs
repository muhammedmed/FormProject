using Microsoft.EntityFrameworkCore;
using WebFormApi.Models;

namespace WebFormApi.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
