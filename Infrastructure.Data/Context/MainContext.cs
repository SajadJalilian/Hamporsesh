using Hamporsesh.Domain.Core.Models;
using Hamporsesh.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamporsesh.Infrastructure.Data.Context
{
    public class MainContext :
        IdentityDbContext<User, Role, long, IdentityUserClaim<long>,
        IdentityUserRole<long>,
        IdentityUserLogin<long>,
        IdentityRoleClaim<long>,
        IdentityUserToken<long>>,
        IUnitOfWork
    {
        private readonly IConfiguration _configuration;


        public MainContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Visitor> Visitors { get; set; }


        /// <summary>
        /// </summary>
        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.Set<TEntity>().AddRange(entities);
        }


        /// <summary>
        /// </summary>
        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.Set<TEntity>().RemoveRange(entities);
        }


        /// <summary>
        /// </summary>
        public void MarkAsModified<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = EntityState.Modified; // Or use ---> this.Update(entity);
        }


        /// <summary>
        /// </summary>
        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = EntityState.Deleted;
        }


        /// <summary>
        /// </summary>
        public int SaveChanges()
        {
            return base.SaveChanges();
        }


        /// <summary>
        /// </summary>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }


        /// <summary>
        /// </summary>
        public TEntity AddAndGet<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var result = base.Add(entity);
            SaveChanges();
            return result.Entity;
        }


        /// <summary>
        /// </summary>
        public async Task<TEntity> AddAndGetAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var result = base.Add(entity);
            await SaveChangesAsync();
            return result.Entity;
        }


        /// <summary>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseType = _configuration["UnitTestDatabaseType"] ?? "SqlServer";
            var databaseName = _configuration["UnitTestDatabaseName"];


            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:MainConnection"]);
        }


        /// <summary>
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<long>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<long>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserRole<long>>().ToTable("UserRoles");
        }
    }
}