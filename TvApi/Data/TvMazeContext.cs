using Microsoft.EntityFrameworkCore;
using TvApi.Models;

namespace TvApi.Data
{
    public class TvMazeContext : DbContext
    {
        public TvMazeContext(DbContextOptions<TvMazeContext> options) : base(options)
        {
        }

        public DbSet<Show> shows { get; set; }
        public DbSet<Cast> casts { get; set; }

        //public DbSet<ShowCast> showCasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Show>().ToTable("Show");
            modelBuilder.Entity<Cast>().ToTable("Cast");          
            //modelBuilder.Entity<ShowCast>().ToTable("ShowCast");
        }
    }
}
