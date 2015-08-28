using System.ComponentModel.DataAnnotations;

namespace Playground.EF.App.Fluent.Models
{
    public class Album
    {
        public int AlbumId { get; protected set; }

        public int ArtistId { get; private set; }

        public string Title { get; protected set; }


        protected Album() { }

        private Album(string title)
        {
            this.Title = title;
        }

        public static Album Generate(string title)
        {
            return new Album(title);
        }
    }
}