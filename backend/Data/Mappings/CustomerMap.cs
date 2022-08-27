using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rainbow_unicorn.Utilities;

namespace rainbow_unicorn.Data.Mappings;

public class CustomerMap : BaseMap<Customer>
{
    public CustomerMap(EntityTypeBuilder<Customer> builder) : base(builder)
    {
        builder.HasKey(e => e.CustomerName);
        builder.Property(e => e.CustomerName).IsRequired();
        builder.Property(e => e.PasswordHash).IsRequired();
        builder.Property(e => e.PasswordSalt).IsRequired();
        builder.Property(u=>u.FullName).IsRequired();
        builder.Property(u=>u.Email).IsRequired();

        builder.HasMany(e => e.CreditCards)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerName)
            .IsRequired();
        
        builder.HasMany(e => e.SolutionCustomers)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerName)
            .IsRequired();

        builder.HasMany(e => e.Users)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerName)
            .IsRequired();
        
        builder.HasMany(e=>e.UserPurchases)
            .WithOne(e=>e.Customer)
            .HasForeignKey(e=>e.CustomerName)
            .IsRequired();
        
        builder.HasMany(e => e.CustomerStocks)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerName)
            .IsRequired();
        
    }
}