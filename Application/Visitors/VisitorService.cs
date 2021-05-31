namespace Hamporsesh.Application.Visitors
{
    public class VisitorService : IVisitorService
    {
        private readonly MainContext _mContext;

        public VisitorService()
        {
            _mContext = new MainContext();
        }


        public long GetOrSetIdByIp(string ip, long pollId)
        {
            var _visitors = _mContext.Set<Visitor>();

            var visitor = _visitors.FirstOrDefault(v => v.IP == ip && v.PollId == pollId);
            if (visitor == null)
                return Create(ip, pollId);

            return visitor.Id;

        }



        public long Create(string ip, long pollId)
        {
            var _visitors = _mContext.Set<Visitor>();

            var createdVisitor = _visitors.Add(new Visitor
            {
                IP = ip,
                PollId = pollId
            });
            _mContext.SaveChanges();
            return createdVisitor.Entity.Id;

        }


        public bool IsDonePollBefore(long pollId, string visitorIp)
        {
            var _visitors = _mContext.Set<Visitor>();
            if (_visitors.Any(v => v.IP == visitorIp && v.PollId == pollId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
