using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rainbow_unicorn.Utilities;

namespace rainbow_unicorn.Data.Mappings;

public class SolutionMap : BaseMap<Solution>
{
    public SolutionMap(EntityTypeBuilder<Solution> builder) : base(builder)
    {
        builder.HasKey(s=>s.SolutionId);
        builder.Property(s=>s.SolutionId).IsRequired();
        builder.Property(s=>s.SolutionTitle).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Organisation).HasMaxLength(150).IsRequired();
        builder.Property(s => s.Description).IsRequired();
        builder.Property(s => s.ReleaseDate).IsRequired();
        builder.Property(s => s.Rating).IsRequired();
        builder.Property(s => s.Category).IsRequired();
        builder.Property(s => s.New).IsRequired();
        
        builder.HasMany(s => s.Features)
            .WithOne(f => f.Solution)
            .HasForeignKey(f => f.SolutionId)
            .IsRequired();
        
        builder.HasMany(e => e.SolutionCustomers)
            .WithOne(e => e.Solution)
            .HasForeignKey(e => e.SolutionId)
            .IsRequired();
    }
}