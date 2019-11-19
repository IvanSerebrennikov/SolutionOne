using System.Collections.Generic;
using System.Linq;
using SO.DataAccess.Entities;
using SO.DataAccess.Interfaces.Repository;
using SO.Domain.UseCases.One.Interfaces;
using SO.Domain.UseCases.One.Models;

namespace SO.Domain.UseCases.One
{
    public class OneDataService : IOneDataService
    {
        private readonly IRepository<City> _citiesRepository;

        public OneDataService(
            IRepository<City> citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public IReadOnlyList<CityModel> GetAllCities()
        {
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
    }
}