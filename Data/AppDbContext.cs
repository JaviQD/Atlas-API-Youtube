using AtlasApis.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlasApis.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options){}

        public DbSet<AtlasPhoto> Photos { get; set; }
    }
}
