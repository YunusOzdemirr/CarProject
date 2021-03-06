using System;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BoatDtos;
using FluentValidation;

namespace CarProject.Business.ValidationRules.FluentValidation.BoatValidator
{
    public class BoatAddValidator : AbstractValidator<BoatAddDto>
    {
        public BoatAddValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
            RuleFor(a => a.Name).MaximumLength(100);
            RuleFor(a => a.Color).NotEmpty();
            RuleFor(a => a.Color).MaximumLength(15);
            RuleFor(a => a.Color).MinimumLength(2);
        }
    }
}

