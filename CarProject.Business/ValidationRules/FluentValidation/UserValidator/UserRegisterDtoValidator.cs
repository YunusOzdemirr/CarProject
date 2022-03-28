using System;
using CarProject.Entities.Dtos.AuthDtos;
using FluentValidation;

namespace CarProject.Business.ValidationRules.FluentValidation.UserValidator
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MaximumLength(100);
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MaximumLength(100);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.EmailAddress).NotEmpty().WithMessage("E-Posta Adresi alanı zorunludur.");
            RuleFor(u => u.EmailAddress).Length(10, 100).WithMessage("E-Posta Adresi alanı en az 10 en fazla 100 karakter olmalıdır");
        }
    }
}

