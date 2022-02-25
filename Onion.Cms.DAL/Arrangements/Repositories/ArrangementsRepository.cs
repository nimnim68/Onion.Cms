using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Arrangements.Entities;
using Onion.Cms.Domain.Arrangements.Repositories;

namespace Onion.Cms.DAL.Arrangements.Repositories
{
    //TODO: Milad: Remove s from class Name
    public class ArrangementsRepository : EfRepository<Arrangement>, IArrangementRepository
    {
        public ArrangementsRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}