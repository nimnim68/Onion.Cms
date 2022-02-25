using Onion.Cms.Domain.Common;
using Onion.Cms.Domain.Interfaces;

namespace Onion.Cms.Domain.Slider.Entities
{
    public class Slider : BaseUserEntity<int>, IAggregateRoot
    {
        public string Title { get; set; }
        public string Src { get; set; }
        public string Description { get; set; }
        public string LinkTitle { get; set; }
        public string Link { get; set; }
    }
}