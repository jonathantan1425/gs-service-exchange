using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rainbow_unicorn.Utilities;

namespace rainbow_unicorn.Data.Mappings;

public class FeatureMap : BaseMap<Feature>
{
    public FeatureMap(EntityTypeBuilder<Feature> builder) : base(builder)
    {
        builder.HasKey(f=>f.FeatureTitle);
        builder.Property(f=>f.FeatureTitle).HasMaxLength(100).IsRequired();
        builder.Property(f => f.Description).IsRequired();
        builder.Property(f => f.SolutionId).IsRequired();
        
        builder.HasOne(f => f.Solution)
            .WithMany(s => s.Features)
            .HasForeignKey(f => f.SolutionId)
            .IsRequired();
    }
}