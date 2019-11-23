using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SO.Domain.UseCases.Admin.Models
{
    public class CityModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime FoundationDate { get; set; }

        public CityScreenLayoutModel ScreenLayout { get; set; }
    }

    public class CityScreenLayoutModel
    {
        public int PercentageX { get; set; }

        public int PercentageY { get; set; }
    }
}
