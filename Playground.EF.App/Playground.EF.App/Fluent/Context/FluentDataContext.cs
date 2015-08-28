using Playground.EF.App.Fluent.Models;
using System.Data.Entity;

namespace Playground.EF.App.Fluent.Context
{
    public class FluentDataContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public FluentDataContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Fluent");
            modelBuilder.Entity<Artist>()
                .ToTable("Artist")
                .HasKey(s => s.ArtistId);

        }
    }

    public class FluentMapping
    {

    }
}