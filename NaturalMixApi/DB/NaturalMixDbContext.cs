using Microsoft.EntityFrameworkCore;
using NaturalMixApi.Models;

namespace NaturalMixApi.DB
{
    public class NaturalMixDbContext: DbContext
    {
        public NaturalMixDbContext(DbContextOptions<NaturalMixDbContext> options): base()
        {
        }

        public DbSet<ComponentItem> ComponentItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=natural_mix;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ComponentItem>().HasKey(c => new { c.Name });
        }
    }
}
