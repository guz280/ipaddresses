﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpWebApi.Models
{
    public class IpDetailsDbContext : DbContext
    {
        public DbSet<Details> Details { get; set; }
        private readonly DbContextOptions<IpDetailsDbContext> _options;
        public DbContextOptions<IpDetailsDbContext> Options
        {
            get
            {
                return _options;
            }
        }
        public IpDetailsDbContext(DbContextOptions<IpDetailsDbContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Details>().ToTable("Details");
        }
    }
}
