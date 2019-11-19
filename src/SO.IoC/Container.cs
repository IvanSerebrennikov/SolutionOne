using System;
using System.Collections.Generic;
using System.Text;
using SO.DataAccess.DbContext;
using SO.DataAccess.Entities;
using SO.DataAccess.Repositories;
using SO.Domain.DataServices;
using SO.Domain.Interfaces.DataServices;

namespace SO.IoC
{
    public static class Container
    {
        public static ICitiesDataService GetCitiesDataService()
        {
            var context = new SolutionOneDbContext();

            return new CitiesDataService(new EntityFrameworkRepository<City, SolutionOneDbContext>(context));
        }
    }
}
