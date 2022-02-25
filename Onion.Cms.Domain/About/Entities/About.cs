using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;

namespace Onion.Cms.Domain.About.Entities
{
    public class About : BaseUserEntity<int>, IAggregateRoot
    {
        public string Src { get; set; }
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }

    }
}