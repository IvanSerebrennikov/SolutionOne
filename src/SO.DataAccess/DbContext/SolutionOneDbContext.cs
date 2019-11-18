using Microsoft.EntityFrameworkCore;
using SO.DataAccess.Entities;
using SO.DataAccess.Entities.ManyToMany;

namespace SO.DataAccess.DbContext
{
    public class SolutionOneDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
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
            options.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SolutionOne;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureOneToOneUserAndUserAdditionalInfo(modelBuilder);

            ConfigureManyToManyUsersAndApartments(modelBuilder);
        }

        private void ConfigureOneToOneUserAndUserAdditionalInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.AdditionalInfo)
                .WithOne(i => i.User)
                .HasForeignKey<UserAdditionalInfo>(b => b.Id);
        }

        private void ConfigureManyToManyUsersAndApartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserApartment>()
                .HasKey(t => new {t.UserId, t.ApartmentId});

            modelBuilder.Entity<UserApartment>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserApartments)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserApartment>()
                .HasOne(ua => ua.Apartment)
                .WithMany(u => u.UserApartments)
                .HasForeignKey(ua => ua.ApartmentId);
        }
    }
}