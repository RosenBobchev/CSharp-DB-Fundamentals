using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfig
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasMany(x => x.PlayerStatistics)
                      .WithOne(x => x.Player)
                      .HasForeignKey(x => x.PlayerId)
                      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
