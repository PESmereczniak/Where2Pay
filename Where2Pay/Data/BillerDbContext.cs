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
                .HasKey(ab => new { ab.AgentID, ab.BillerID });

            modelBuilder.Entity<AgentsBillers>()
                .HasOne(ab => ab.Agent)
                .WithMany(b => b.AgentsBillers)
                .HasForeignKey(ab => ab.AgentID);

            modelBuilder.Entity<AgentsBillers>()
                .HasOne(ab => ab.Biller)
                .WithMany(a => a.AgentsBillers)
                .HasForeignKey(ab => ab.BillerID);
        }
    }
}
