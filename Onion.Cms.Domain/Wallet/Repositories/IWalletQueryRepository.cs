using System.Threading.Tasks;

namespace Onion.Cms.Domain.Wallet.Repositories
{
    public interface IWalletQueryRepository
    {
        Task<decimal> BalanceUserWalletAsync(string userName);
    }
}