using System.Linq;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hamporsesh.Application.Visitors
{
    public class VisitorService : IVisitorService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Visitor> _visitors;



        public VisitorService(IUnitOfWork uow)
        {
            _uow = uow;
            _visitors = uow.Set<Visitor>();
        }


            public long GetOrSetIdByIp(string ip, long pollId)
        {
            var visitor = _visitors.FirstOrDefault(v => v.IP == ip && v.PollId == pollId);
            if (visitor == null)
                return Create(ip, pollId);

            return visitor.Id;
        }


        public long Create(string ip, long pollId)
        {
            var createdVisitor = _visitors.Add(new Visitor
            {
                IP = ip,
                PollId = pollId
            });

            return createdVisitor.Entity.Id;
        }


        public bool IsDonePollBefore(long pollId, string visitorIp)
        {
            if (_visitors.Any(v => v.IP == visitorIp && v.PollId == pollId))
                return true;
            return false;
        }
    }
}