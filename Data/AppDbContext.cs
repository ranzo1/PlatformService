using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        // base(opt)?
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
    }
}