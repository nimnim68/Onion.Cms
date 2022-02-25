using AutoMapper;
using Onion.Cms.Domain.Product.Commands.Brands;
using Onion.Cms.Domain.Product.Commands.Categories;
using Onion.Cms.Domain.Product.Dtos.Brands;
using Onion.Cms.Domain.Product.Dtos.Categories;
using Onion.Cms.Domain.Slider.Commands;
using Onion.Cms.Domain.Slider.Dtos;

namespace Onion.Cms.Web.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<GetBrandDto, EditBrandDto>();
            CreateMap<EditBrandDto, BrandUpdateCommand>();

            CreateMap<GetCategoryDto, EditCategoryDto>();
            CreateMap<EditCategoryDto, CategoryUpdateCommand>();

            CreateMap<SliderDto, EditSliderDto>();
            CreateMap<EditSliderDto, UpdateSliderCommand>();

            CreateMap<SliderDto, Domain.Slider.Entities.Slider>();

        }
    }
}