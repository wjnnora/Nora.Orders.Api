using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Infrastructure.Database.EntityFramework.Mapping;

public sealed class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(nameof(OrderItem));

        builder.HasKey(k => k.Id);
        builder.Property(p => p.ProductId);
        builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");

        builder.HasOne(p => p.Order)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(p => p.OrderId);
    }
}