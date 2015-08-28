using Playground.EF.App.Models;
using System.Data.Entity;

namespace Playground.EF.App.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DataContext() : base()
        {

        }
    }
}