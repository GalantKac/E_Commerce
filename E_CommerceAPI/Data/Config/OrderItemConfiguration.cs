using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductLibrary.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //relacja order item z item ordered
            builder.OwnsOne(i => i.ItemOrdered, io => io.WithOwner());

            builder.Property(i => i.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
