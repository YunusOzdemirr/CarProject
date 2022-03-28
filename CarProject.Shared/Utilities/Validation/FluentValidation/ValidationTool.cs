using System;
using System.Collections.Generic;
using CarProject.Shared.Entities.Concrete;
using CarProject.Shared.Utilities.Exceptions;
using FluentValidation;

namespace CarProject.Shared.Utilities.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                IList<Error> validationErrors = new List<Error>();
                foreach (var error in result.Errors)
                {
                    validationErrors.Add(new Error
                    {
                        PropertyName = error.PropertyName,
                        Message = error.ErrorMessage
                    });
                }
                throw new ValidationErrorsException("Bir veya daha fazla validasyon hatasına rastlandı.", validationErrors);
            }
        }
    }
}
