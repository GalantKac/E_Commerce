using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductLibrary.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // shipToAddress bedzie zawarty w tabeli order (nie bedzie miec osobnej tabeli)
            builder.OwnsOne(o => o.ShipToAddress, a =>
            {
                a.WithOwner();
            });

            //mapowanie z bazy i do bazy
            //w bazie ma byc stringiem, w progrmaie enumem
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );

            builder.Property(i => i.Subtotal)
                .HasColumnType("decimal(18,2)");

            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
