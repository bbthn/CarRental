using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttinConsern.Validation
{
    public class ValidationTool 
    {
        public static void Validate(IValidator validator,object tentity)
        {
            var context = new ValidationContext<object>(tentity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
                
            }
        }
    }
}
