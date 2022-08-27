using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rainbow_unicorn.Utilities;

namespace rainbow_unicorn.Data.Mappings;

public class CustomerStockMap : BaseMap<CustomerStock>
{
    public CustomerStockMap(EntityTypeBuilder<CustomerStock> builder) : base(builder)
    {
        builder.HasKey(e => new{ e.Ticker, e.CustomerName});
        builder.Property(e => e.CustomerName).IsRequired();
        builder.Property(e=>e.Ticker).IsRequired();
        builder.Property(e=>e.Interval).IsRequired();

        builder.HasOne(e => e.Stock)
            .WithMany(e => e.CustomerStocks)
            .HasForeignKey(e => e.Ticker)
            .IsRequired();

        builder.HasOne(e => e.Customer)
            .WithMany(e => e.CustomerStocks)
            .HasForeignKey(e => e.CustomerName)
            .IsRequired();

    }
}