using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Domain.User.Repositories;
using Onion.Cms.Domain.Zone.Entities;

namespace Onion.Cms.DAL.User.Repositories
{
    public class UserAddressRepository : EfRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Domain.Zone.Entities.Zone>> ListZoneAllAsync(bool asNoTracking = false)
        {
            return (await DbContext.Zones.ToListAsync()).AsReadOnly();
        }

        public async Task<IReadOnlyList<Province>> ListProvinceAllAsync(long? zoneId = null, bool asNoTracking = false)
        {
            if (zoneId.HasValue)
            {
                return (await DbContext.Provinces.Where(x => x.ZoneId == zoneId).ToListAsync()).AsReadOnly();
            }
            return (await DbContext.Provinces.ToListAsync()).AsReadOnly();
        }
        public async Task<IReadOnlyList<District>> ListDistrictAllAsync(long? provinceId = null, bool asNoTracking = false)
        {
            if (provinceId.HasValue)
            {
                return (await DbContext.Districts.Where(x => x.ProvinceId == provinceId).ToListAsync()).AsReadOnly();
            }
            return (await DbContext.Districts.ToListAsync()).AsReadOnly();
        }
    }
}