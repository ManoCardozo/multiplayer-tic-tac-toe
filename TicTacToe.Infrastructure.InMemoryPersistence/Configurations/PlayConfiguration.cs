using TicTacToe.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicTacToe.Infrastructure.Persistence.Configurations
{
    public class PlayConfiguration : IEntityTypeConfiguration<Play>
    {
        public void Configure(EntityTypeBuilder<Play> builder)
        {
            builder.HasKey(p => p.PlayId);

            builder.Property(p => p.PlayerId);

            builder
                .HasOne(p => p.Player)
                .WithMany(b => b.Plays);
        }
    }
}
