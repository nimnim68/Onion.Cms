using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Cms.Domain.Interfaces;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Domain.Zone.Entities;

namespace Onion.Cms.Domain.User.Repositories
{
    public interface IUserAddressRepository : IAsyncRepository<UserAddress>
    {
        Task<IReadOnlyList<Zone.Entities.Zone>> ListZoneAllAsync(bool asNoTracking = false);
        Task<IReadOnlyList<Province>> ListProvinceAllAsync(long? zoneId=null,bool asNoTracking = false);
        Task<IReadOnlyList<District>> ListDistrictAllAsync(long? provinceId = null, bool asNoTracking = false);
    }
}