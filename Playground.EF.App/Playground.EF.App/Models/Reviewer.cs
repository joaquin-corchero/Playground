using System.Collections.Generic;

namespace Playground.EF.App.Models
{
    public class Reviewer : BaseModel
    {
        public int ReviewerId { get; protected set; }

        public string Name { get; protected set; }

        public virtual List<Album> Albums { get; protected set; }
    }
}
