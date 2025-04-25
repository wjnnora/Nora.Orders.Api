using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Infrastructure.Database.EntityFramework.Mapping;

public sealed class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order));

        builder.HasKey(k => k.Id);        
        builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");

        builder.OwnsOne(o => o.Customer, a =>
        {
            a.WithOwner();

            a.Property(p => p.Id)
                .IsRequired()
                .HasColumnName("CustomerId");

            a.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("CustomerName");            

        }).Navigation(p => p.Customer).IsRequired();
    }
}