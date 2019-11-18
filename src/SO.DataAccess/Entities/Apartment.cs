using System;
using System.Collections.Generic;
using System.Text;
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

        public List<User> Users { get; set; } = new List<User>();
    }
}
