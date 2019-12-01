using System.Collections.Generic;
using System.Linq;
using SO.Domain.DataAccessInterfaces.Repository;
using SO.Domain.Entities;
using SO.Domain.UseCases.One.Interfaces;
using SO.Domain.UseCases.One.Models;

namespace SO.Domain.UseCases.One
{
    public class OneService : IOneService
    {
        private readonly IRepository<City, int> _citiesRepository;

        public OneService(
            IRepository<City, int> citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public IReadOnlyList<CityWithApartmentsCountModel> GetAllCities()
        {
            var models = _citiesRepository.GetProjections<CityWithApartmentsCountModel>(
                x => new CityWithApartmentsCountModel
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