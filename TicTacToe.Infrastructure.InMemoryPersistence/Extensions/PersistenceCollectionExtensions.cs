using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicTacToe.Infrastructure.Persistence;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PersistenceCollectionExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<TicTacToeContext>(options => 
                {
                    options
                        .UseLazyLoadingProxies()
                        .UseInMemoryDatabase(configuration.GetValue<string>("DatabaseName"));
                });

            services.AddScoped<ITicTacToeContext, TicTacToeContext>();
        }
    }
}
