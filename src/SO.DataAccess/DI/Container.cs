using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SO.DataAccess.DbContext;
using SO.DataAccess.Interfaces.Repository;
using SO.DataAccess.Repositories;

namespace SO.DataAccess.DI
{
    public static class Container
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
        }
    }
}