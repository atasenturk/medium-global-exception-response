using FluentValidation;
using ResponseModelWebApi.DTOs;
using ResponseModelWebApi.Models;

namespace ResponseModelWebApi.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid!");
        }

    }
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid!");
        }

    }
}
