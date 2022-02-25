using AutoMapper;
using MediatR;
using Onion.Cms.ApplicationServices.Specifications;
using Onion.Cms.Domain.User.Dtos;
using Onion.Cms.Domain.User.Queries;
using Onion.Cms.Domain.User.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Onion.Cms.ApplicationServices.User.Queries
{
    public class UserInfoQueryHandler :
        IRequestHandler<GetApplicationUserInfoQuery, ApplicationUserInfoDto>
    {

        private readonly IApplicationUserInfoCommandRepository _repository;
        private readonly IMapper _mapper;

        public UserInfoQueryHandler(IApplicationUserInfoCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApplicationUserInfoDto> Handle(GetApplicationUserInfoQuery request, CancellationToken cancellationToken)
        {
            var rec = await _repository.FirstOrDefaultAsync(
                new ApplicationUserInfoSpecification(request.ApplicationUserId));
            if (rec != null)
                return new ApplicationUserInfoDto()
                {
                    ApplicationUserId = rec.ApplicationUserId,
                    FirstName = rec.FirstName,
                    LastName = rec.LastName,
                    NationalCode = rec.NationalCode,
                    Birthdate = rec.Birthdate,
                    Gender = rec.Gender,
                };
            return null;
        }
    }
}