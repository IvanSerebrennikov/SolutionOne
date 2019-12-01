using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SO.Domain.Entities;
using SO.Domain.Entities.Identity;

namespace SO.DataAccess.DbContext
{
    public class SolutionOneDbContext : ApiAuthorizationDbContext<AppIdentityUser>
    {
        public SolutionOneDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        { }

        public DbSet<User> SolutionOneUsers { get; set; }
        public DbSet<UserAdditionalInfo> SolutionOneUserAdditionalInfos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SolutionOneDbContextModelCreationRules.Apply(modelBuilder);
        }
    }
}