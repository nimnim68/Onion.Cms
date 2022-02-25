using AutoMapper;
using MediatR;
using Onion.Cms.Domain.Blogs.Entities;
using Onion.Cms.Domain.Blogs.Repositories;
using Onion.Cms.Domain.Product.Commands.Products;
using Onion.Cms.Domain.SeedWork;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Resources.Interface;
using Onion.Cms.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Onion.Cms.Domain.Blogs.Commands.Posts;

namespace Onion.Cms.ApplicationServices.Blogs.Commands
{
    public class PostCommandHandler :
        IRequestHandler<PostCreateCommand, ResultDto>,
        IRequestHandler<PostDeleteCommand, ResultDto>,
        IRequestHandler<PostUpdateCommand, ResultDto>
    {
        private readonly IPostRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;
        private readonly ResultDto _result;

        public PostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IResourceManager resourceManager, IPostRepository repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _resourceManager = resourceManager;
            _result = new ResultDto(_resourceManager);
            _repository = repository;
        }

        public async Task<ResultDto> Handle(PostCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Post
            {
                CreateDate = DateTime.Now,
                CreatorUserId = request.CreatorUserId,
                CategoryId = request.CategoryId,
                Title = request.Title,
                IsActive=request.IsActive,
                Content=request.Content,
                Image=request.Image,
                Description=request.Description,
                Tages=request.Tags,
            };
            await _repository.AddAsync(entity);
            _result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
            return _result;
        }

        public async Task<ResultDto> Handle(PostUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repository.GetByIdAsync(request.Id);
                if (data != null)
                {
                    data.CategoryId = request.CategoryId;
                    data.Title = request.Title;
                    data.Description = request.Description;
                    if (!string.IsNullOrWhiteSpace(request.Image) )
                    {
                        data.Image = request.Image;
                    }
                    data.ModifiedDate = DateTime.Now;
                    data.ModifiedId = request.ModifierUserId;

                    _result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
                }
                else
                {
                    _result.IsSuccess = false;
                    _result.AddError(SharedResource.NotFound);
                }
            }
            catch (Exception e)
            {
                _result.Message = e.Message;
                _result.IsSuccess = false;
                _result.AddError(SharedResource.SaveError);
            }


            return _result;
        }

        public async Task<ResultDto> Handle(PostDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity != null)
                {
                    entity.ModifiedId = request.ModifierUserId;
                    _repository.Delete(entity);
                    _result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
                    _result.Message = _result.IsSuccess ? _resourceManager[SharedResource.DeleteMessage] : _resourceManager[SharedResource.SaveError];
                }
                else
                {
                    _result.IsSuccess = false;
                    _result.AddError(SharedResource.NotFound);
                }
            }
            catch (Exception e)
            {
                _result.Message = _resourceManager[SharedResource.SaveError];
                _result.IsSuccess = false;
                _result.AddError(e.Message);
            }
            return _result;
        }
    }
}
