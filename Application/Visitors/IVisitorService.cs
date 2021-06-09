namespace Hamporsesh.Application.Visitors
{
    public interface IVisitorService
    {
        long GetOrSetIdByIp(string ip, long pollId);

        long Create(string ip, long pollId);

        bool IsDonePollBefore(long pollId, string visitorIp);
    }
}