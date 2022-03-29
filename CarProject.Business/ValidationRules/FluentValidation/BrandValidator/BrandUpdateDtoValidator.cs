using System;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BrandDtos;
using FluentValidation;

namespace CarProject.Business.ValidationRules.FluentValidation.BrandValidator
{
    public class BrandUpdateDtoValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateDtoValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Id).GreaterThanOrEqualTo(1);
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
            RuleFor(a => a.Name).MaximumLength(100);
        }
    }
}

