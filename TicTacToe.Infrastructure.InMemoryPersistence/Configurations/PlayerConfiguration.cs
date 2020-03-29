using TicTacToe.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicTacToe.Infrastructure.Persistence.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.PlayerId);

            builder
                .Property(p => p.Name)
                .HasMaxLength(50);

            builder
                .Property(p => p.Symbol);

            builder
                .HasOne(p => p.Match)
                .WithMany(b => b.Players)
                .HasForeignKey(p => p.MatchId);
        }
    }
}
