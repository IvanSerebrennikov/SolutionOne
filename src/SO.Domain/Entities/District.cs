using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.Domain.DataAccessInterfaces.Entity;
using SO.Domain.Entities.Owns;

namespace SO.Domain.Entities
{
    public class District : IEntity
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public int LivingStandard { get; set; }

        public ScreenLayout ScreenLayout { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public List<Street> Streets { get; set; } = new List<Street>();
    }
}