using TicTacToe.Core.Application.Services;
using TicTacToe.Core.Application.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<IBoardService, BoardService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IBoxService, BoxService>();
            services.AddTransient<IMatchResultService, MatchResultService>();
        }
    }
}
