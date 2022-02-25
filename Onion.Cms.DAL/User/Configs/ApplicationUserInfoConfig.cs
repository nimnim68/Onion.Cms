using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.DAL.User.Configs
{
    public class ApplicationUserInfoConfig : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(250);
            builder.Property(c => c.Birthdate).HasColumnType("DateTime");
            builder.Property(c => c.NationalCode).HasColumnType("nchar(10)").HasMaxLength(10);
        }
    }
}
