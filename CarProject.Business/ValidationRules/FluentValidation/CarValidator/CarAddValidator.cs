using System;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.CarDtos;
using FluentValidation;

namespace CarProject.Business.ValidationRules.FluentValidation.CarValidator
{
    public class CarAddValidator : AbstractValidator<CarAddDto>
    {
        public CarAddValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
            RuleFor(a => a.Name).MaximumLength(100);
            RuleFor(a => a.Color).NotEmpty();
        }
    }
}

