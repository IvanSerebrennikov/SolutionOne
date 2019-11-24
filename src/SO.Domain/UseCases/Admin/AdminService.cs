using System;
using System.Linq;
using AMQPSharedData.Messages;
using SO.Domain.DataAccessInterfaces.Repository;
using SO.Domain.Entities;
using SO.Domain.Entities.Owns;
using SO.Domain.InfrastructureInterfaces.MessageProducing;
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
        private readonly IMessageProducer _messageProducer;

        public AdminService(
            IRepository<City> citiesRepository,
            PostResultFactory postResultFactory,
            IMessageProducer messageProducer)
        {
            _citiesRepository = citiesRepository;
            _postResultFactory = postResultFactory;
            _messageProducer = messageProducer;
        }

        public CitySavedResult CreateCity(CityModel cityModel)
        {
            var cityName = ProcessCityName(cityModel.Name);

            // TODO: use any mapper (AutoMapper, Mapster)
            var city = new City
            {
                Name = cityName,
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

                _messageProducer.ProduceCityCreated(new CityCreatedMessage
                {
                    SolutionOneCityId = city.Id,
                    Name = city.Name,
                    FoundationDate = city.FoundationDate
                });

                return _postResultFactory.Success<CitySavedResult>(additionalSetup: x => x.CityId = city.Id);
            }
            // TODO: catch custom DbSave exception
            catch (Exception e)
            {
                return _postResultFactory.Error<CitySavedResult>("Unexpected error", e);
            }
        }

        #region City name processing

        private string ProcessCityName(string requestedName)
        {
            requestedName = requestedName.Trim();

            // Swagger example default string value
            const string exampleName = "string";

            if (string.IsNullOrWhiteSpace(requestedName) || requestedName == exampleName) 
                return GenerateCityName();

            var isCityWithRequestedNameExist = _citiesRepository.Get(x => x.Name == requestedName).Any();

            if (isCityWithRequestedNameExist) 
                return GenerateCityName(requestedName);

            return requestedName;
        }

        private static string GenerateCityName(string firstPart = null)
        {
            return $"{firstPart ?? "City"} {Guid.NewGuid().ToString().Replace("-", "")}";
        }

        #endregion
    }
}