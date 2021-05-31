using Hamporsesh.Domain.Core.Enums;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollOutputViewModelAdmin
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public string CreateDateTimeStr { get; set; }
        public long TotalResponses { get; set; }
        public PollStatus Status { get; set; }
    }
}
