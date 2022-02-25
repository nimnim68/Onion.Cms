using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Onion.Cms.Domain.Payments.Commands;
using Onion.Cms.Domain.Payments.Entities;
using Onion.Cms.Domain.Payments.Repositories;
using Onion.Cms.Domain.SeedWork;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Resources.Interface;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.ApplicationServices.Payments.Command
{
    public class PaymentCommandHandler :
                 IRequestHandler<AddPaymentCommand, ResultDto>
    {

        private readonly IPaymentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;
        private readonly ResultDto _result;

        public PaymentCommandHandler(IPaymentRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IResourceManager resourceManager)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _resourceManager = resourceManager;
            _result = new ResultDto(_resourceManager);
        }

        public async Task<ResultDto> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (IsValid())
                {
                    var payment = new Payment()
                    {
                        CreateDate = DateTime.Now,
                        CreatorUserId = request.CreatorUserId,
                        IsRemoved = false,
                        Id = Guid.NewGuid(),
                        Amount = request.Amount,
                        IsPay = request.IsPay,
                        Authority = request.Authority,
                        OrderId = request.OrderId,
                        RefId = request.RefId,
                        PayDate = request.PayDate,
                        StatusCode = request.StatusCode,
                        StatusCodeMessage = request.StatusCodeMessage,
                        PaymentType = request.PaymentType,
                        
                    };
                    await _repository.AddAsync(payment);
                    _result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;
                }
            }
            catch (Exception e)
            {
                _result.Message = e.Message;
                _result.AddError(SharedResource.SaveError);
                _result.IsSuccess = false;
            }

            return _result;


        }

        private bool IsValid()
        {
            return true;
        }
    }
}