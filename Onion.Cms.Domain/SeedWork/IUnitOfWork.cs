using System.Threading;
using System.Threading.Tasks;

namespace Onion.Cms.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        int Commit();

    }
}