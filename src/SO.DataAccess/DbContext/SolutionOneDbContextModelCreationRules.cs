using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SO.Domain.Entities;
using SO.Domain.Entities.ManyToMany;

namespace SO.DataAccess.DbContext
{
    internal static class SolutionOneDbContextModelCreationRules
    {
        public static List<Action<ModelBuilder>> Rules = new List<Action<ModelBuilder>>
        {
            OneToOneUserAndUserAdditionalInfo,
            ManyToManyUsersAndApartments
        };

        public static void Apply(ModelBuilder modelBuilder)
        {
            Rules.ForEach(rule => rule(modelBuilder));
        }

        #region Rules

        private static void OneToOneUserAndUserAdditionalInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.AdditionalInfo)
                .WithOne(i => i.User)
                .HasForeignKey<UserAdditionalInfo>(b => b.Id);
        }

        private static void ManyToManyUsersAndApartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserApartment>()
                .HasKey(ua => new { ua.UserId, ua.ApartmentId });

            modelBuilder.Entity<UserApartment>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserApartments)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserApartment>()
                .HasOne(ua => ua.Apartment)
                .WithMany(a => a.UserApartments)
                .HasForeignKey(ua => ua.ApartmentId);
        }

        #endregion
    }
}