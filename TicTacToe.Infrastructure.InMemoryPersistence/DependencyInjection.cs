using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<TicTacToeContext>(options => 
                {
                    options
                        .UseLazyLoadingProxies()
                        .UseInMemoryDatabase(configuration.GetValue<string>("DatabaseName"));
                });

            return services;
        }
    }
}
