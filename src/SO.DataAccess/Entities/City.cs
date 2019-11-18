using System;
using System.Collections.Generic;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class City : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime FoundationDate { get; set; }

        public List<District> Districts { get; set; } = new List<District>();
    }
}
