using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using System.Linq;

namespace Hamporsesh.Application.Visitors
{
    public class VisitorService : IVisitorService
    {
        private readonly IUnitOfWork _uow;

        public VisitorService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public long GetOrSetIdByIp(string ip, long pollId)
        {
            var _visitors = _uow.Set<Visitor>();

            var visitor = _visitors.FirstOrDefault(v => v.IP == ip && v.PollId == pollId);
            if (visitor == null)
                return Create(ip, pollId);

            return visitor.Id;

        }



        public long Create(string ip, long pollId)
        {
            var _visitors = _uow.Set<Visitor>();

            var createdVisitor = _visitors.Add(new Visitor
            {
                IP = ip,
                PollId = pollId
            });
            _uow.SaveChanges();
            return createdVisitor.Entity.Id;

        }


        public bool IsDonePollBefore(long pollId, string visitorIp)
        {
            var _visitors = _uow.Set<Visitor>();
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
