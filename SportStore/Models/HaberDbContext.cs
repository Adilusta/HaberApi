using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class HaberDbContext : DbContext
    {
        public HaberDbContext(DbContextOptions<HaberDbContext> options)
            : base(options) { }
        public DbSet<Haber> Haberler { get; set; }
       
    

    }
}
