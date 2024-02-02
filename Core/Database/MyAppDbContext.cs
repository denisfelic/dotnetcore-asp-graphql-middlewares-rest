using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Models;
using dotnetcore_asp.Core.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_asp.Core.Database
{
    public class MyAppDbContext : DbContext
    {

        public DbSet<Bookmarker> Bookmarkers { get; set; }

        public string DbPath { get; }

        public MyAppDbContext()
        {

            // var path = "/";
            DbPath = "todosdb.db"; //System.IO.Path.Join(path, "todosdb.db");
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmarker>()
            .HasMany(b => b.Bookmarkers)
            .WithOne()
            .HasForeignKey(b => b.BookmarkerId)
            .OnDelete(DeleteBehavior.Cascade);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}