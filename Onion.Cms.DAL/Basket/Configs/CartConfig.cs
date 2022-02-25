﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Cms.Domain.Basket.Entities;

namespace Onion.Cms.DAL.Basket.Configs
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(x => x.UserIp).HasColumnType("varchar(18)").HasMaxLength(18);
            builder.Property(x => x.BrowserName).HasColumnType("nvarchar(150)").HasMaxLength(150);
        }
    }
}