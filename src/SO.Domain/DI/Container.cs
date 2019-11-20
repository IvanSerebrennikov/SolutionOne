using Microsoft.Extensions.DependencyInjection;
using SO.Domain.UseCases.One;
using SO.Domain.UseCases.One.Interfaces;

namespace SO.Domain.DI
{
    public static class Container
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOneDataService, OneDataService>();
        }
    }
}