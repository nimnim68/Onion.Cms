using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Onion.Cms.Domain.Basket.Dtos;
using Onion.Cms.Domain.Enum;
using Onion.Cms.Domain.User.Dtos.UserAddresses;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.Web.Models
{
    public class ShippingViewModel
    {
        public CartPayDto CartPayDto { get; set; }
        public List<UserAddressDto> UserAddressDtos { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Address)] 
        public int UserAddressId { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.OrderPostType)]
        public OrderPostType OrderPostType { get; set; }
        
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.PaymentType)]
        public PaymentType PaymentType { get; set; }
    }
}