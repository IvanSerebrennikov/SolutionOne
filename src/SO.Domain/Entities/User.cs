using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.Domain.DataAccessInterfaces.Entity;
using SO.Domain.Entities.Identity;
using SO.Domain.Entities.ManyToMany;

namespace SO.Domain.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(450)]
        public string AspNetUserId { get; set; }

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