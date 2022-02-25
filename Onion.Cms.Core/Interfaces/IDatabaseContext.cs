using Microsoft.EntityFrameworkCore;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Domain.Wallet.Entities;
using Onion.Cms.Domain.Zone.Entities;

namespace Onion.Cms.ApplicationServices.Interfaces
{
    public interface IDatabaseContext
    {
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserInfo> ApplicationUserInfos { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Domain.Wallet.Entities.Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
    }
}