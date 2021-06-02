namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollOutputDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public string CreateDateTimeStr { get; set; }
        public long TotalResponses { get; set; }
    }
}
