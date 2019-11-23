using System;
using SO.Domain.DataAccessInterfaces.Repository;
using SO.Domain.Entities;
using SO.Domain.Entities.Owns;
using SO.Domain.UseCases._Base.Models.PostResults;
using SO.Domain.UseCases.Admin.Interfaces;
using SO.Domain.UseCases.Admin.Models;
using SO.Domain.UseCases.Admin.Models.PostResults;

namespace SO.Domain.UseCases.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<City> _citiesRepository;
        private readonly PostResultFactory _postResultFactory;

        public AdminService(
            IRepository<City> citiesRepository,
            PostResultFactory postResultFactory)
        {
            _citiesRepository = citiesRepository;
            _postResultFactory = postResultFactory;
        }

        public CitySavedResult CreateCity(CityModel cityModel)
        {
            // TODO: use any mapper (AutoMapper, Mapster)
            var city = new City
            {
                Name = cityModel.Name,
                FoundationDate = cityModel.FoundationDate,
                ScreenLayout = cityModel.ScreenLayout != null
                    ? new ScreenLayout
                    {
                        PercentageX = cityModel.ScreenLayout.PercentageX,
                        PercentageY = cityModel.ScreenLayout.PercentageY
                    }
                    : null
            };

            // TODO: try to encapsulate exceptions handling logic for all repo.Save actions for all use cases
            try
            {
                _citiesRepository.Create(city);
                _citiesRepository.Save();

                // TODO: send city created message to RabbitMQ

                return _postResultFactory.Success<CitySavedResult>(additionalSetup: x => x.CityId = city.Id);
            }
            // TODO: catch custom DbSave exception
            catch (Exception e)
            {
                return _postResultFactory.Error<CitySavedResult>("Unexpected error", e);
            }
        }
    }
}