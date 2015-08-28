using Playground.EF.App.Fluent.Models;
using System.Data.Entity;

namespace Playground.EF.App.Fluent.Context
{

    public class ContextInitializer : DropCreateDatabaseIfModelChanges<FluentDataContext>
    {
        protected override void Seed(FluentDataContext context)
        {
            /*var soloArtist = SoloArtist.Generate("Solo artist 1", Address.Generate("1", "A Street"), "SeedArtist1");
            soloArtist.Add(Album.Generate("Seed Album 1-1"));
            soloArtist.Add(Album.Generate("Seed Album 1-2"));
            context.Artists.Add(soloArtist);

            var artist = Artist.Generate("Seed artist 2", Address.Generate("2", "A Street"), "Seed2");
            artist.Add(Album.Generate("Seed Album 2-1"));
            artist.Add(Album.Generate("Seed Album 2-2"));

            context.Artists.Add(artist);

            context.SaveChanges();
            InitializeDatabase(context);*/
        }
    }
}