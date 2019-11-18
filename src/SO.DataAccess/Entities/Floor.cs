using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class Floor : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int EntranceId { get; set; }

        public Entrance Entrance { get; set; }

        public List<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
