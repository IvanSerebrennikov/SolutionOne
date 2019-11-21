using System.Collections.Generic;
using SO.Domain.DataAccessInterfaces.Entity;
using SO.Domain.Entities.ManyToMany;

namespace SO.Domain.Entities
{
    public class Apartment : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int CountOfRooms { get; set; }

        public int FloorId { get; set; }

        public Floor Floor { get; set; }

        public List<UserApartment> UserApartments { get; set; } = new List<UserApartment>();
    }
}