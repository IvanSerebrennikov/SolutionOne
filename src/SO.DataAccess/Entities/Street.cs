using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class Street : IEntity
    {
        public int Id { get; set; }

        [MaxLength(512)]
        public string Name { get; set; }

        public int DistrictId { get; set; }

        public District District { get; set; }

        public List<House> Houses { get; set; } = new List<House>();
    }
}