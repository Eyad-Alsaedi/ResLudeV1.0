using ExpertsGulfPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertsGulfPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Arbitrators> Arbitrators { get; set; }
        public DbSet<RequestArbitrators> RequestArbitrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the RequestArbitrators entity
            modelBuilder.Entity<RequestArbitrators>()
                .ToTable("RequestArbitrators");

            // You can add additional configuration for RequestArbitrators here if needed
            // For example, setting up indexes, relationships, or column types
        }
    }
}