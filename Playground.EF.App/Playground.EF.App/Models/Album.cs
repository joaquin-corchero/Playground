using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Playground.EF.App.Models
{
    public class Album : BaseModel
    {
        public int AlbumId { get; protected set; }

        public int ArtistId { get; private set; }

        [Required]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "The Title must be at between 10 and 250characters in lenght")]
        public string Title { get; protected set; }


        //Many to many
        public virtual List<Reviewer> Reviewers { get; set; }

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