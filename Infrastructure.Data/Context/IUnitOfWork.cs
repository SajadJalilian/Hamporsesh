using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hamporsesh.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hamporsesh.Infrastructure.Data.Context
{
    public interface IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsModified<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class;
        void ExecuteSqlCommand(string query);
        void ExecuteSqlCommand(string query, params object[] parameters);

        int SaveChanges();
        Task<int> SaveChangesAsync();
        void SetGeographyField<TEntity>(TEntity entity, string latitude, string longitude, string entityName = null, string columnName = "Location") where TEntity : BaseEntity;
        TEntity AddAndGet<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task<TEntity> AddAndGetAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
