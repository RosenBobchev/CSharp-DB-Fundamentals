using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfig
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasMany(x => x.Players)
                      .WithOne(x => x.Team)
                      .HasForeignKey(x => x.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.HomeGames)
               .WithOne(x => x.HomeTeam)
               .HasForeignKey(x => x.HomeTeamId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AwayGames)
               .WithOne(x => x.AwayTeam)
               .HasForeignKey(x => x.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
