using System;
using System.Collections.Generic;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class Street : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }

        public District District { get; set; }

        public List<House> Houses { get; set; } = new List<House>();
    }
}
