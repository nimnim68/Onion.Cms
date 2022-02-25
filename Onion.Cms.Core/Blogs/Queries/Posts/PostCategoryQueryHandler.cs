using AutoMapper;
using MediatR;
using Onion.Cms.ApplicationServices.Specifications.Blogs;
using Onion.Cms.ApplicationServices.Specifications.Slider;
using Onion.Cms.Domain.Blogs.Entities;
using Onion.Cms.Domain.Blogs.Queries.PostCategories;
using Onion.Cms.Domain.Blogs.Queries.Posts;
using Onion.Cms.Domain.Blogs.Repositories;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Resources.Interface;
using Onion.Cms.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Onion.Cms.Domain.Blogs.Dtos;

namespace Onion.Cms.ApplicationServices.Blogs.Queries.Posts
{
    public class PostCategoryQueryHandler :
          IRequestHandler<PostCategoryListQuery, QueryList<PostCategoryListQueryDto>>,
            IRequestHandler<PostCategoryGetByIdQuery, ResultDto<PostCategoryGetQueryDto>>
    {

        private readonly IPostCategoryRepository _repository;

        private readonly ResultDto<PostCategoryGetQueryDto> _result;
        public PostCategoryQueryHandler(IPostCategoryRepository repository,  IResourceManager resourceManager)
        {
            _repository = repository;
            _result = new ResultDto<PostCategoryGetQueryDto>(resourceManager);
        }

        public async Task<QueryList<PostCategoryListQueryDto>> Handle(PostCategoryListQuery request, CancellationToken cancellationToken)
        {
            var spec = new PostCategorySpecification(request.SearchKey);
            var count = await _repository.CountAsync(spec);
            var res = await _repository.GetPagedRespondAsync(spec, request.PageSize, request.Skip);
            var lst = res.Select(s => new PostCategoryListQueryDto
            {
                Id = s.Id,
                Title = s.Title,
                PostCount = s.Posts?.Count ?? 0
            }) .ToList();
            return new QueryList<PostCategoryListQueryDto> { Data = lst, TotalCount = count };
        }

        public async Task<ResultDto<PostCategoryGetQueryDto>> Handle(PostCategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FirstOrDefaultAsync(new PostCategorySpecification(request.Id));
            if (result != null)
            {
                _result.Data = new PostCategoryGetQueryDto
                {
                    Id = result.Id,
                    Title = result.Title,
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
