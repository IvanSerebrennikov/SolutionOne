using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SO.DataAccess.DbContext
{
    internal static class SolutionOneDbContextOptionsConfiguration
    {
        public static void Configure(DbContextOptionsBuilder<SolutionOneDbContext> builder,
            IConfiguration configuration)
        {
            builder
                .UseSqlServer(configuration.GetConnectionString("OneConnection"))
                .UseLoggerFactory(LoggerFactories.ConsoleLoggerFactory);
        }
    }
}