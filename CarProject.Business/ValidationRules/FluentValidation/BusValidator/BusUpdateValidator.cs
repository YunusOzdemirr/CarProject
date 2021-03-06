using System;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BusDtos;
using FluentValidation;

namespace CarProject.Business.ValidationRules.FluentValidation.BusValidator
{
    public class BusUpdateValidator : AbstractValidator<BusUpdateDto>
    {
        public BusUpdateValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Id).GreaterThanOrEqualTo(1);
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
            RuleFor(a => a.Name).MaximumLength(100);
            RuleFor(a => a.Color).NotEmpty();
            RuleFor(a => a.Color).MaximumLength(15);
            RuleFor(a => a.Color).MinimumLength(2);
            RuleFor(a => a.Wheels).NotEmpty();
            RuleFor(a => a.Headlights).NotEmpty();
        }
    }
}

