using Microsoft.AspNetCore.Identity;

namespace Onion.Cms.Domain.User.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}