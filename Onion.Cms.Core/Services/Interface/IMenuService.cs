using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Cms.Domain.DTOs.Site.Common;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.ApplicationServices.Services.Interface
{
    public interface IMenuService
    {
        ResultDto<List<MenuDto>> GetMenu();
        Task<ResultDto<IReadOnlyList<MenuDto>>> GetMenuAsync();
    }
}