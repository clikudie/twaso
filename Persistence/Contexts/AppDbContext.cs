using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twaso.Domain.Models;

namespace Twaso.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Url>().ToTable("Url");
            modelBuilder.Entity<Url>().HasKey(p => p.Hash);
            modelBuilder.Entity<Url>().Property(p => p.Hash).IsRequired();
            modelBuilder.Entity<Url>().Property(p => p.OriginalUrl).IsRequired();
            modelBuilder.Entity<Url>().Property(p => p.CreationDate).IsRequired();
            modelBuilder.Entity<Url>().Property(p => p.ExpirationDate).IsRequired();
        }
    }
}
