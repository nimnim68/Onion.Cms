using FluentValidation;
using Onion.Cms.Domain.User.Commands;

namespace Onion.Cms.ApplicationServices.User.Command
{
    public class CreateUserInfoCommandValidator : AbstractValidator<AddApplicationUserInfoCommand>
    {
        public CreateUserInfoCommandValidator()
        {
            RuleFor(x => x.NationalCode).MinimumLength(10).MaximumLength(10).WithErrorCode("");
        }
    }
}