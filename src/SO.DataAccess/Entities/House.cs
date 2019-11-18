using System;
using System.Collections.Generic;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class House : IEntity
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public int StreetId { get; set; }

        public Street Street { get; set; }

        public List<Entrance> Entrances { get; set; } = new List<Entrance>();
    }
}
