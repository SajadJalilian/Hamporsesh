namespace Hamporsesh.Infrastructure.Data.Context
{
    public class MainContext:IdentityDbContext<User, Role, long>
    {
        //private readonly IConfiguration _configuration;
        //public MainContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public MainContext()
        {
           
        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Visitor> Visitors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=.;Database=Hamporsesh;Trusted_Connection=True;MultipleActiveResultSets=true");
           
        }

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
