using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.DataAccess.Entities.ManyToMany;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
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

        public UserAdditionalInfo AdditionalInfo { get; set; }

        public List<UserApartment> UserApartments { get; set; } = new List<UserApartment>();
    }
}