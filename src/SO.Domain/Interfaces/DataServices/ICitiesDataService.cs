using System.Collections.Generic;
using SO.Domain.Models;

namespace SO.Domain.Interfaces.DataServices
{
    public interface ICitiesDataService
    {
        IReadOnlyList<CityModel> GetCitiesByNames(params string[] names);
    }
}
