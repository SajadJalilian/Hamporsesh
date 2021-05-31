namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollOutputViewModelParticipation
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public string CreateDateTimeStr { get; set; }
    }
}
