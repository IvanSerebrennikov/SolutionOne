using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.Domain.DataAccessInterfaces.Entity;

namespace SO.Domain.Entities
{
    public class House : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Number { get; set; }

        [MaxLength(512)]
        public string Name { get; set; }

        public int StreetId { get; set; }

        public Street Street { get; set; }

        public List<Entrance> Entrances { get; set; } = new List<Entrance>();
    }
}