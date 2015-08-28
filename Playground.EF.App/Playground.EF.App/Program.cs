using Playground.EF.App.Models;
using Playground.EF.App.Repositories;
using System;
using System.Linq;

namespace Playground.EF.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var artistRepo = new ArtistRepository();

            WriteConnectionString(artistRepo);

            AddOrUpdateArtistIfExists(artistRepo);

            DisplayArtists(artistRepo);

            DisplaySoloArtists(artistRepo);

            Console.ReadKey();
        }

        private static void WriteConnectionString(ArtistRepository artistRepo)
        {
            Console.WriteLine(string.Format("Connection string: {0}", artistRepo.ConnectionString));
        }

        private static void AddOrUpdateArtistIfExists(ArtistRepository artistRepo)
        {
            var artist = Artist.Generate("First artist", Address.Generate("1", "BB Street"), "The first artist");
            artist.Add(Album.Generate("First Title"));
            artist.Add(Album.Generate("Second Title"));

            var existingArtist = artistRepo.GetByName(artist.Name).FirstOrDefault();

            if (existingArtist == null)
            {
                artistRepo.Add(artist);
            }
            else
            {
                existingArtist.SetNickName(string.Format("Artist updated {0}", DateTime.Now));
                artistRepo.Update(existingArtist);
            }

            artistRepo.SaveChanges();
        }

        private static void DisplayArtists(ArtistRepository artistRepo)
        {
            var artists = artistRepo.GetAll();

            Console.WriteLine("All artists found");

            if (artists.Any())
                artists.ForEach(a => WriteArtist(a));
            else
                Console.WriteLine("No artists found");
        }

        private static void WriteArtist(Artist artist)
        {
            Console.WriteLine(string.Format("- Artist: {0}", artist.ToString()));
            WriteAlbums(artist);
        }

        private static void WriteAlbums(Artist artist)
        {
            artist.Albums.ForEach(a => Console.WriteLine(string.Format("   - Album: {0}", a.Title)));
        }

        private static void DisplaySoloArtists(ArtistRepository artistRepo)
        {
            var artists = artistRepo.GetSoloArtists();

            Console.WriteLine("Solo artists found");
            if (artists.Any())
                artists.ForEach(a => WriteArtist(a));
            else
                Console.WriteLine("No Solo artists found");
        }
    }
}
