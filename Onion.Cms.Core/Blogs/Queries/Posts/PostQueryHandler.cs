using AutoMapper;
using MediatR;
using Onion.Cms.ApplicationServices.Specifications.Blogs;
using Onion.Cms.Domain.Blogs.Entities;
using Onion.Cms.Domain.Blogs.Queries.Posts;
using Onion.Cms.Domain.Blogs.Repositories;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Resources.Interface;
using Onion.Cms.Resources.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Onion.Cms.Domain.Blogs.Dtos;

namespace Onion.Cms.ApplicationServices.Blogs.Queries.Posts
{
    public class PostQueryHandler :
          IRequestHandler<PostGetByIdQuery, ResultDto<PostGetQueryDto>>
         , IRequestHandler<PostPaginationQueries, QueryList<PostListQueryDto>>
    {

        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;
        private readonly ResultDto<PostGetQueryDto> _result;
        public PostQueryHandler(IPostRepository repository, IMapper mapper, IResourceManager resourceManager)
        {
            _repository = repository;
            _mapper = mapper;
            _result = new ResultDto<PostGetQueryDto>(resourceManager);
        }

        public async Task<ResultDto<PostGetQueryDto>> Handle(PostGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FirstOrDefaultAsync(new PostSpecification(request.Id));
            if (result != null)
            {
                _result.Data = new PostGetQueryDto()
                {
                    CreateDate = result.CreateDate,
                    CreatorUserId = result.ModifiedId,
                    ModifiedDate = result.ModifiedDate,
                    IsRemoved = result.IsRemoved,
                    ModifiedId = result.ModifiedId,
                    RemoveTime = result.RemoveTime,


                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Content=result.Content,
                    Image = result.Image,
                    Tages = result.Tages,

                    CategoryId=result.CategoryId,
                    CategoryTitle=result.Category?.Title
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

        public async Task<QueryList<PostListQueryDto>> Handle(PostPaginationQueries request, CancellationToken cancellationToken)
        {
            var spec = new PostSpecification(request.SearchKey,request.CategoryId);
            var count = await _repository.CountAsync(spec);
            var res = await _repository.GetPagedRespondAsync(spec, request.PageSize, request.Skip);
            var lst = Mapper(res);
            return new QueryList<PostListQueryDto> { Data = lst, TotalCount = count };
        }

        private IReadOnlyList<PostListQueryDto> Mapper(IReadOnlyList<Post> list)
        {
            var lst = list.Select(x => new PostListQueryDto()
            {
                CreateDate = x.CreateDate,
                CreatorUserId = x.ModifiedId,
                ModifiedDate = x.ModifiedDate,
                IsRemoved = x.IsRemoved,
                ModifiedId = x.ModifiedId,
                RemoveTime = x.RemoveTime,

                Description = x.Description,
                Id = x.Id,
                Image = x.Image,
                Title = x.Title,

                CategoryId=x.CategoryId,
                CategoryTitle=x.Category?.Title,
                BloggerName=x.ApplicationUser?.UserName
            }).ToList().AsReadOnly();
            return lst;
        }

    }
}
