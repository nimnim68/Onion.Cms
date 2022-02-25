using System.ComponentModel.DataAnnotations;

namespace Onion.Cms.Domain.Enum
{
    public enum OrderType
    {
        [Display(Name = "ascending")]
        Ascending = 1,
        [Display(Name = "descending")]
        Descending
    }
}