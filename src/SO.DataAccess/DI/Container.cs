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
            services.AddDbContext<SolutionOneDbContext>(options =>
                options.UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SolutionOne;Integrated Security=True;"));

            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
        }
    }
}