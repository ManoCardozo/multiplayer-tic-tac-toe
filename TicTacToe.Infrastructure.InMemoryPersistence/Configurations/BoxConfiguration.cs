using TicTacToe.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicTacToe.Infrastructure.Persistence.Configurations
{
    public class BoxConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.HasKey(p => p.BoxId);

            builder.Property(p => p.BoxPosition);

            builder.Property(p => p.BoardId);

            builder.Property(p => p.MarkedById);

            builder
                .HasOne(p => p.MarkedBy)
                .WithMany(p => p.FilledBoxes)
                .HasForeignKey(p => p.MarkedById);

            builder
                .HasOne(p => p.Board)
                .WithMany(p => p.Boxes)
                .HasForeignKey(p => p.BoardId);
        }
    }
}
