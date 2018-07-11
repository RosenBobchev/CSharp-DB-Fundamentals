using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfig
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasMany(c => c.PrimaryKitTeams)
                   .WithOne(c => c.PrimaryKitColor)
                   .HasForeignKey(c => c.PrimaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SecondaryKitTeams)
                   .WithOne(c => c.SecondaryKitColor)
                   .HasForeignKey(c => c.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
