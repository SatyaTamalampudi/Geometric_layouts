using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeometricLayouts.Models.Validations
{
    public class GreaterThanZeroAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var x = value as int? ?? 0;

            return x <= 0 ? new ValidationResult($"{context?.DisplayName} Must be greater than Zero.") : ValidationResult.Success;
        }
    }
}
