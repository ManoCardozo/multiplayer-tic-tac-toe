using TicTacToe.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicTacToe.Infrastructure.Persistence.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(p => p.MatchId);

            builder
                .HasOne(p => p.Board)
                .WithOne(p => p.Match)
                .HasForeignKey<Board>(p => p.MatchId);
        }
    }
}
