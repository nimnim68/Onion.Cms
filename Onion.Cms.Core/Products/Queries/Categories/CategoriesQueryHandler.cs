using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Onion.Cms.ApplicationServices.Specifications.Products;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.Product.Dtos.Categories;
using Onion.Cms.Domain.Product.Entities;
using Onion.Cms.Domain.Product.Queries.Categories;
using Onion.Cms.Domain.Product.Repositories.Categories;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Resources.Interface;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.ApplicationServices.Products.Queries.Categories
{
    public class CategoriesQueryHandler :
        IRequestHandler<GetCategoryQueries, IReadOnlyList<GetCategoryDto>>,
        IRequestHandler<GetCategoryPaginationQueries, QueryList<GetCategoryDto>>,
        IRequestHandler<GetCategoryByIdQueries, ResultDto<GetCategoryDto>>
    {
        private readonly ICategoryCommandRepository _repository;
        private readonly IMapper _mapper;
        private readonly ResultDto<GetCategoryDto> _result;


        public CategoriesQueryHandler(ICategoryCommandRepository repository, IMapper mapper, IResourceManager resourceManager)
        {
            _repository = repository;
            _mapper = mapper;
            _result = new ResultDto<GetCategoryDto>(resourceManager);
        }

        public async Task<IReadOnlyList<GetCategoryDto>> Handle(GetCategoryQueries request, CancellationToken cancellationToken)
        {
            var res = await _repository.ListAllAsync();
            var lst = Mapper(res);
            return lst;
        }

        public async Task<QueryList<GetCategoryDto>> Handle(GetCategoryPaginationQueries request, CancellationToken cancellationToken)
        {
            var spec = new CategorySpecification(request.SearchKey);
            var count = await _repository.CountAsync(spec);
            var res = await _repository.GetPagedRespondAsync(spec, request.PageSize, request.Skip);
            var lst = Mapper(res);
            return new QueryList<GetCategoryDto> { Data = lst, TotalCount = count };
        }

        private IReadOnlyList<GetCategoryDto> Mapper(IReadOnlyList<Category> list)
        {
            var lst = list.Select(x => new GetCategoryDto()
            {
                CreateDate = x.CreateDate,
                CreatorUserId = x.ModifiedId,
                ModifiedDate = x.ModifiedDate,
                IsRemoved = x.IsRemoved,
                ModifiedId = x.ModifiedId,
                RemoveTime = x.RemoveTime,

                Icon = x.Icon,
                Id = x.Id,
                ParentId = x.ParentId,
                Title = x.Title,

                Parent = x.Parent != null ? new GetCategoryDto()
                {
                    Id = x.Parent.Id,
                    Title = x.Parent.Title
                } : null,
                ParentName = x.Parent?.Title
            }).ToList().AsReadOnly();
            return lst;
        }

        public async Task<ResultDto<GetCategoryDto>> Handle(GetCategoryByIdQueries request, CancellationToken cancellationToken)
        {
            var result = await _repository.FirstOrDefaultAsync(new CategorySpecification(request.Id));
            if (result != null)
            {
                _result.Data = new GetCategoryDto()
                {
                    CreateDate = result.CreateDate,
                    CreatorUserId = result.ModifiedId,
                    ModifiedDate = result.ModifiedDate,
                    IsRemoved = result.IsRemoved,
                    ModifiedId = result.ModifiedId,
                    RemoveTime = result.RemoveTime,

                    Icon = result.Icon,
                    Id = result.Id,
                    ParentId = result.ParentId,
                    Title = result.Title,

                    Parent = result.Parent != null
                        ? new GetCategoryDto()
                        {
                            Id = result.Parent.Id,
                            Title = result.Parent.Title
                        }
                        : null,
                    ParentName = result.Parent?.Title
                };
                _result.IsSuccess = true;
            }
            else
            {
                _result.IsSuccess = false;
                _result.AddError(SharedResource.NotFound);
            }
            return _result;
        }
    }
}