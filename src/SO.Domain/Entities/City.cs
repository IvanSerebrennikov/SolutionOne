using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SO.Domain.DataAccessInterfaces.Entity;

namespace SO.Domain.Entities
{
    public class City : IEntity
    {
        public int Id { get; set; }

        [MaxLength(512)]
        public string Name { get; set; }

        public DateTime FoundationDate { get; set; }

        public List<District> Districts { get; set; } = new List<District>();
    }
}