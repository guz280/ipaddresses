using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpWebApi.Models
{
    public class IpDetailsDbContext : DbContext
    {
        public DbSet<Details> Details { get; set; }
        public IpDetailsDbContext(DbContextOptions<IpDetailsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Details>().ToTable("Details");
        }
    }
}
