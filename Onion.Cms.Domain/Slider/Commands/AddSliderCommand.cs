using MediatR;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Dtos;

namespace Onion.Cms.Domain.Slider.Commands
{
    public class AddSliderCommand : BaseCommandEntity, IRequest<ResultDto>
    {
        public string Title { get; set; }
        public string Src { get; set; }
        public string Description { get; set; }
        public string LinkTitle { get; set; }
        public string Link { get; set; }
    }
}