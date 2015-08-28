using Playground.EF.App.Models;
using System.Data.Entity;

namespace Playground.EF.App.Context
{

    public class ContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var soloArtist = SoloArtist.Generate("Solo artist 1", Address.Generate("1", "A Street"), "SeedArtist1");
            soloArtist.Add(Album.Generate("Seed Album 1-1"));
            soloArtist.Add(Album.Generate("Seed Album 1-2"));
            context.Artists.Add(soloArtist);

            var artist = Artist.Generate("Seed artist 2", Address.Generate("2", "A Street"), "Seed2");
            artist.Add(Album.Generate("Seed Album 2-1"));
            artist.Add(Album.Generate("Seed Album 2-2"));

            context.Artists.Add(artist);

            context.SaveChanges();
            InitializeDatabase(context);
        }
    }
}