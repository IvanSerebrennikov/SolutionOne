using System;
using SO.Domain.DataAccessInterfaces.Entity;

namespace SO.Domain.Entities
{
    public class UserAdditionalInfo : IEntity
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public User User { get; set; }
    }
}