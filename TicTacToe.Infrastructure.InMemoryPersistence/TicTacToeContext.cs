using Microsoft.EntityFrameworkCore;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Infrastructure.Persistence
{
    public class TicTacToeContext : DbContext, ITicTacToeContext
    {
        public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options)
        {

        }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Play> Plays { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicTacToeContext).Assembly);
        }
    }
}