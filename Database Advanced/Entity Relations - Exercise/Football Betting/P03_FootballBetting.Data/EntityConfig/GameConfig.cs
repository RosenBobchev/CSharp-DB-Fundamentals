using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
namespace P03_FootballBetting.Data.EntityConfig
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasMany(x => x.Bets)
                   .WithOne(x => x.Game)
                   .HasForeignKey(x => x.GameId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PlayerStatistics)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
