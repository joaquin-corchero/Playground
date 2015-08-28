using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Playground.EF.App.Fluent.Models
{
    public class Artist
    {
        public int ArtistId { get; protected set; }

        public string Name { get; protected set; }

        public string NickName { get; protected set; }

        [Timestamp()]//For optimistic concurrency
        public byte[] RowVersion { get; set; }

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