using System.ComponentModel.DataAnnotations;

namespace Playground.EF.App.Models
{
    public class BaseModel
    {
        [Timestamp()]//For optimistic concurrency
        public byte[] RowVersion { get; protected set; }
    }
}
