﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Cms.Domain.Orders.Entities;

namespace Onion.Cms.DAL.Orders.Configs
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(c => c.FinalPrice).HasColumnType("decimal(18,2)").HasPrecision(18, 2).IsRequired();
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)").HasPrecision(18, 2).IsRequired();
            builder.Property(c => c.DiscountPrice).HasColumnType("decimal(18,2)").HasPrecision(18, 2).IsRequired();
        }
    }
}