using Microsoft.EntityFrameworkCore;
using Onion.Cms.DAL.Context;
using Onion.Cms.Domain.Wallet.Repositories;

namespace Onion.Cms.DAL.Wallet.Repositories
{
    public class WalletCommandRepository : IWalletCommandRepository
    {

        private readonly DatabaseContext _dbContext;

        public WalletCommandRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}