using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Playground.EF.App.Models
{
    public class Artist : BaseModel
    {
        public int ArtistId { get; protected set; }

        [Required]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "The Name must be at between 10 and 250 characters in lenght")]
        public string Name { get; protected set; }

        [StringLength(250, ErrorMessage = "The Nick Name must be less than 250 characters in lenght")]
        public string NickName { get; protected set; }

        public virtual List<Album> Albums { get; protected set; }

        public virtual Address Address { get; protected set; }

        protected Artist() { }

        protected Artist(string name, Address address, string nickName = null)
        {
            Name = name;
            Address = address;
            SetNickName(nickName);
        }

        public static Artist Generate(string name, Address address, string nickName = null)
        {
            return new Artist(name, address, nickName);
        }

        public void Add(Album album)
        {
            if (Albums == null)
                Albums = new List<Album>();

            Albums.Add(album);
        }

        internal void SetNickName(string nickName)
        {
            NickName = nickName;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}, living in {3}", ArtistId, Name, NickName, Address.ToString());
        }

    }
}