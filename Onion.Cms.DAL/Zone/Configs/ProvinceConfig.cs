using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Cms.Domain.Zone.Entities;

namespace Onion.Cms.DAL.Zone.Configs
{
    public class ProvinceConfig : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
        }
    }
}