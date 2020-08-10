using TicTacToe.Infrastructure.Repository;
using TicTacToe.Infrastructure.Repository.UnitOfWork;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryCollectionExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<IGenericRepository, GenericRepository>();
        }
    }
}
