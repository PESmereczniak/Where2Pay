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

        public BillerDbContext(DbContextOptions<BillerDbContext> options)
            : base(options)
        {
        }
    }
}
