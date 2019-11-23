using System.Collections.Generic;
using SO.Domain.UseCases.One.Models;

namespace SO.Domain.UseCases.One.Interfaces
{
    public interface IOneService
    {
        IReadOnlyList<CityWithApartmentsCountModel> GetAllCities();
    }
}
