using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hamporsesh.Domain.Core.Models;
using Hamporsesh.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hamporsesh.Infrastructure.Data.Context
{
    public class MainContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>,
        IdentityRoleClaim<long>, IdentityUserToken<long>>, IUnitOfWork
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Ctor

        public MainContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Properties

        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        #endregion

        #region protected Methods

        /// <summary>
        /// 
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseType = _configuration["UnitTestDatabaseType"] ?? "SqlServer";
            var databaseName = _configuration["UnitTestDatabaseName"];

            if (databaseType.Equals("InMemoryDatabase"))
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: databaseName);
            }
            else if (databaseType.Equals("Sqlite"))
            {
                optionsBuilder.UseSqlite(@"Data Source=C:\Sqlite-UnitTest\" + databaseName + ".db");
            }
            else
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:MainConnection"]);
            }
        }


        /// <summary>
        /// 
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

        #endregion

        #region Public Methods

        #region IUnitOfWork Implementations

        /// <summary>
        /// 
        /// </summary>
        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.Set<TEntity>().AddRange(entities);
        }


        /// <summary>
        /// 
        /// </summary>
        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.Set<TEntity>().RemoveRange(entities);
        }


        /// <summary>
        /// 
        /// </summary>
        public void MarkAsModified<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = EntityState.Modified; // Or use ---> this.Update(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Deleted;
        }


        /// <summary>
        /// 
        /// </summary>
        public void ExecuteSqlCommand(string query)
        {
            base.Database.ExecuteSqlCommand(query);
        }


        /// <summary>
        /// 
        /// </summary>
        public void ExecuteSqlCommand(string query, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(query, parameters);
        }


        /// <summary>
        /// 
        /// </summary>
        public int SaveChanges()
        {
            return base.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        public void SetGeographyField<TEntity>(TEntity entity, string latitude, string longitude,
            string entityName = null, string columnName = "Location") where TEntity : BaseEntity
        {
            entityName = entityName ?? entity.GetType().Name + "s";
            var query = FormattableString.Invariant(
                $"update [{entityName}] set {columnName} = geography::Point({latitude}, {longitude}, 4326) WHERE Id = '{entity.Id}';");
            ExecuteSqlCommand(query);
        }


        /// <summary>
        /// 
        /// </summary>
        public TEntity AddAndGet<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var result = base.Add(entity);
            SaveChanges();
            return result.Entity;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> AddAndGetAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var result = base.Add(entity);
            await SaveChangesAsync();
            return result.Entity;
        }

        #endregion

        #endregion
    }
}