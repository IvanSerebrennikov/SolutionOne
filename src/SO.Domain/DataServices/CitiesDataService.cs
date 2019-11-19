using System;
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
            return _repository
                .Get(x => names.Contains(x.Name))
                .Select(x => new CityModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }
    }
}