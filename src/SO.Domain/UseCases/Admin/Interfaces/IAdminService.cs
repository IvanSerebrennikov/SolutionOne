using System;
using System.Collections.Generic;
using System.Text;
using SO.Domain.UseCases.Admin.Models;
using SO.Domain.UseCases.Admin.Models.PostResults;

namespace SO.Domain.UseCases.Admin.Interfaces
{
    public interface IAdminService
    {
        CitySavedResult CreateCity(CityModel cityModel);
    }
}
