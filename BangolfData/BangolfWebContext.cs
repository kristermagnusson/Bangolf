using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BangolfModels;


namespace BangolfData
{
    public class BangolfWebContext : DbContext
    {
        public BangolfWebContext (DbContextOptions<BangolfWebContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<BangolfModels.Arena> Arena { get; set; } 

        public DbSet<BangolfModels.Player>? Player { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BangolfModels.Player>()
                .HasMany(s => s.Arenas)
                .WithMany(c => c.Players)
                .UsingEntity<Competition>(
                e => e.HasOne(e => e.Arena).WithMany(c => c.Competitions),
                e => e.HasOne(e => e.Player).WithMany(s => s.Competitions));

           // modelBuilder.Entity<Arena>().Property(c=> c.Name).HasColumnName("Arena");

              

        }
    }
}
