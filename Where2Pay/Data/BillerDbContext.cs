using Where2Pay.Models;
using Microsoft.EntityFrameworkCore;

namespace Where2Pay.Data
{
    public class BillerDbContext : DbContext
    {
        public DbSet<Biller> Billers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentsBillers> AgentsBillers { get; set; }

        public BillerDbContext(DbContextOptions<BillerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentsBillers>()
                .HasKey(a => new { a.AgentID, a.BillerID });
        }
    }
}
