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
        private readonly IRepository<City> _citiesRepository;
        private readonly IRepository<Street> _streetsRepository;

        public CitiesDataService(
            IRepository<City> citiesRepository,
            IRepository<Street> streetsRepository)
        {
            _citiesRepository = citiesRepository;
            _streetsRepository = streetsRepository;
        }

        public IReadOnlyList<CityModel> GetAllCities()
        {
            // Projections Test

            var models = _citiesRepository.GetProjections<CityModel>(
                x => new CityModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ApartmentsCount = x.Districts
                        .SelectMany(d => d.Streets
                            .SelectMany(s => s.Houses
                                .SelectMany(h => h.Entrances
                                    .SelectMany(e => e.Floors
                                        .SelectMany(f => f.Apartments))))).Count()
                });

            return models;
        }

        public IReadOnlyList<CityModel> GetCitiesByNames(params string[] names)
        {
            // Lazy Loading Test

            var entities = _citiesRepository
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

        public IReadOnlyList<StreetModel> GetStreetsByCityName(string cityName)
        {
            // Expressions and Includes Test

            var entities = _streetsRepository
                .Get(
                    x => x.District.City.Name == cityName);

            var models = entities.Select(x => new StreetModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return models;
        }
    }
}