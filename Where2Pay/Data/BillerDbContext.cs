using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Where2Pay.Models;

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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AgentsBillers>()
        //        .HasKey(a => new { a.AgentID, a.BillerID });

        //    foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //    {
        //        relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //    }

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
