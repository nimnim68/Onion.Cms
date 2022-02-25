using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Data;
using Onion.Cms.Domain.Slider.Repositories;

namespace Onion.Cms.DAL.Slider.Repositories
{
    public class SliderRepository :EfRepository<Domain.Slider.Entities.Slider>, ISliderRepository
    {
        public SliderRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}