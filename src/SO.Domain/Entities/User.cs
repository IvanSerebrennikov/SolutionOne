using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.Domain.DataAccessInterfaces.Entity;
using SO.Domain.Entities.ManyToMany;

namespace SO.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string FirstName { get; set; }

        [MaxLength(256)]
        public string MiddleName { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }

        [MaxLength(64)]
        public string UserName { get; set; }

        [MaxLength(64)]
        public string NormalizedUserName { get; set; }

        public string PasswordHash { get; set; }

        public UserAdditionalInfo AdditionalInfo { get; set; }

        public List<UserApartment> UserApartments { get; set; } = new List<UserApartment>();
    }
}