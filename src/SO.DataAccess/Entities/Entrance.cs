using System;
using System.Collections.Generic;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class Entrance : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int HouseId { get; set; }

        public House House { get; set; }

        public List<Floor> Floors { get; set; } = new List<Floor>();
    }
}
