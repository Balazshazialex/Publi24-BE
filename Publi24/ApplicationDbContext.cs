using Microsoft.EntityFrameworkCore;
using Publi24.Entities;

namespace Publi24
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>()
               .HasIndex(a => new { a.Isin }).IsUnique();
        }
    }
}
