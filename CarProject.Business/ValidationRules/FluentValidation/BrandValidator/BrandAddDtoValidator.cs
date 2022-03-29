using System;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BrandDtos;
using FluentValidation;

namespace CarProject.Business.ValidationRules.FluentValidation.BrandValidator
{
    public class BrandAddDtoValidator : AbstractValidator<BrandAddDto>
    {
        public BrandAddDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
            RuleFor(a => a.Name).MaximumLength(100);
        }
    }
}

