using Hamporsesh.Domain.Core.Models;

namespace Hamporsesh.Domain.Entities
{
    public class Visitor: BaseEntity
    {
        public string IP { get; set; }
        public long PollId { get; set; }
    }
}
