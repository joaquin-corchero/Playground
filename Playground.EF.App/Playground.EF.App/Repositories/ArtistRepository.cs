using Playground.EF.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Playground.EF.App.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {

        public List<Artist> GetByName(string name)
        {
            return DbSet.Where(o => o.Name.Contains(name)).ToList();
        }

        public List<SoloArtist> GetSoloArtists()
        {
            return DbSet.OfType<SoloArtist>().ToList();
        }
    }
}
