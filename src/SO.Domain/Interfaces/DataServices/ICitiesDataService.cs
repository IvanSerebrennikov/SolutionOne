﻿using System.Collections.Generic;
using SO.Domain.Models;

namespace SO.Domain.Interfaces.DataServices
{
    public interface ICitiesDataService
    {
        IReadOnlyList<CityModel> GetAllCities();

        IReadOnlyList<CityModel> GetCitiesByNames(params string[] names);

        IReadOnlyList<StreetModel> GetStreetsByCityName(string cityName);
    }
}
