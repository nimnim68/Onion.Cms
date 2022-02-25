using AutoMapper;
using MediatR;
using Onion.Cms.ApplicationServices.Specifications.Products;
using Onion.Cms.Domain.Product.Dtos.Brands;
using Onion.Cms.Domain.Product.Queries.Brands;
using Onion.Cms.Domain.Product.Repositories.Brands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Onion.Cms.ApplicationServices.Products.Queries.Brands
{
    public class GetBrandQueryHandler :
        IRequestHandler<GetBrandQueries, IReadOnlyList<GetBrandDto>>,
        IRequestHandler<GetBrandByIdQueries, GetBrandDto>
    {
        private readonly IBrandsCommandRepository _repository;
        private readonly IMapper _mapper;

        public GetBrandQueryHandler(IBrandsCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetBrandDto>> Handle(GetBrandQueries request, CancellationToken cancellationToken)
        {
            var spec = new BrandSpecification(request.SearchKey, request.SortColumn);
            var count = await _repository.CountAsync(spec);
            var res = await _repository.GetPagedRespondAsync(spec, request.PageSize, request.Skip);
            var lst = res?.Select(x => new GetBrandDto
            {
                Description = x.Description,
                EnglishTitle = x.EnglishTitle,
                Src = x.Src,
                Title = x.Title,
                Id = x.Id,
                Count = count
            }).ToList().AsReadOnly();
            return lst;
        }


        public async Task<GetBrandDto> Handle(GetBrandByIdQueries request, CancellationToken cancellationToken)
        {
            var result = await _repository.FirstOrDefaultAsync(new BrandSpecification(request.Id));
            if (result != null)
            {
                return new GetBrandDto
                {
                    Description = result.Description,
                    EnglishTitle = result.EnglishTitle,
                    Src = result.Src,
                    Title = result.Title,
                    Id = result.Id
                };
            }
            return null;
        }
    }
}