using Microsoft.EntityFrameworkCore;
using SO.Domain.Entities;

namespace SO.DataAccess.DbContext
{
    public class SolutionOneDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SolutionOneDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }
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
            SolutionOneDbContextModelCreationRules.Apply(modelBuilder);
        }
    }
}