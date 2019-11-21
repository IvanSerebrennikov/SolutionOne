using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SO.DataAccess.DbContext;
using SO.DataAccess.Repositories;
using SO.Domain.DataAccessInterfaces.Repository;

namespace SO.DataAccess.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SolutionOneDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OneConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
        }
    }
}