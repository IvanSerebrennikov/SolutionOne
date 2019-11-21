using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.Domain.DataAccessInterfaces.Entity;

namespace SO.Domain.Entities
{
    public class Entrance : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        public int HouseId { get; set; }

        public House House { get; set; }

        public List<Floor> Floors { get; set; } = new List<Floor>();
    }
}