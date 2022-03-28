using System;
using CarProject.Entities.Concrete;
using FluentValidation;

namespace CarProject.Business.ValidationRules.FluentValidation.CarValidator
{
    public class CarUpdateValidator : AbstractValidator<Car>
    {
        public CarUpdateValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(2);
            RuleFor(a => a.Name).MaximumLength(100);
            RuleFor(a => a.Color).NotEmpty();
        }
    }
}

