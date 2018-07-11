using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfig
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasMany(x => x.Players)
                   .WithOne(x => x.Position)
                   .HasForeignKey(x => x.PositionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
