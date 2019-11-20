using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SO.DataAccess.DbContext;
using SO.DataAccess.Interfaces.Repository;
using SO.DataAccess.Repositories;
using SO.Domain.UseCases.One;
using SO.Domain.UseCases.One.Interfaces;

namespace SO.IoC
{
    public static class Container
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<SolutionOneDbContext>(options =>
                options.UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SolutionOne;Integrated Security=True;"));

            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
        }

        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOneDataService, OneDataService>();
        }
    }
}