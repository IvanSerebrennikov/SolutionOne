using System.Collections.Generic;
using SO.DataAccess.Entities.ManyToMany;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
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