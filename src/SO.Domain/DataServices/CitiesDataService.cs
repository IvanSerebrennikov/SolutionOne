using System.Collections.Generic;
using System.Linq;
using SO.DataAccess.Entities;
using SO.DataAccess.Interfaces.Repository;
using SO.Domain.Interfaces.DataServices;
using SO.Domain.Models;

namespace SO.Domain.DataServices
{
    public class CitiesDataService : ICitiesDataService
    {
        private readonly IRepository<City> _repository;

        public CitiesDataService(IRepository<City> repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<CityModel> GetCitiesByNames(params string[] names)
        {
            // Lazy Loading Test

            var entities = _repository
                .Get(
                    x => names.Contains(x.Name),
                    includeProperties: "Districts.Streets.Houses.Entrances.Floors.Apartments");

            var models = entities.Select(x => new CityModel
            {
                Id = x.Id,
                Name = x.Name,
                ApartmentsCount = x.Districts
                    .SelectMany(d => d.Streets
                        .SelectMany(s => s.Houses
                            .SelectMany(h => h.Entrances
                                .SelectMany(e => e.Floors
                                    .SelectMany(f => f.Apartments))))).Count()
            }).ToList();

            return models;
        }
    }
}