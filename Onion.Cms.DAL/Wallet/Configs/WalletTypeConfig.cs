using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Cms.Domain.Wallet.Entities;

namespace Onion.Cms.DAL.Wallet.Configs
{
    public class WalletTypeConfig : IEntityTypeConfiguration<WalletType>
    {
        public void Configure(EntityTypeBuilder<WalletType> builder)
        {
            //builder.Property(c => c.Code).ValueGeneratedNever();
            //builder.Property(c => c.Title).IsRequired().HasMaxLength(200);


        }
    }
}
