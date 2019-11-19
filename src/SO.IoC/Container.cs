using SO.DataAccess.DbContext;
using SO.DataAccess.Entities;
using SO.DataAccess.Repositories;
using SO.Domain.UseCases.One;
using SO.Domain.UseCases.One.Interfaces;

namespace SO.IoC
{
    public static class Container
    {
        public static IOneDataService GetCitiesDataService()
        {
            var context = new SolutionOneDbContext();

            return new OneDataService(
                new EntityFrameworkRepository<City, SolutionOneDbContext>(context));
        }
    }
}