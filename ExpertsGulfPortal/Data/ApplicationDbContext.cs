using ExpertsGulfPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertsGulfPortal.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Arbitrators> Arbitrators {  get; set; }
    }
}
