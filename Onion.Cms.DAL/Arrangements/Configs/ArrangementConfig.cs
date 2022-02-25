using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Cms.Domain.Arrangements.Entities;

namespace Onion.Cms.DAL.Arrangements.Configs
{
    public class ArrangementConfig : IEntityTypeConfiguration<Arrangement>
    {
        public void Configure(EntityTypeBuilder<Arrangement> builder)
        {
            builder.HasOne(x => x.Store).WithOne(x => x.Arrangement).HasForeignKey<Arrangement>(x => x.StoreId);
        }
    }
}