using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeometricLayouts.Models.Validations
{
    public class CharCountAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public CharCountAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var x = value as string;
            var result = string.IsNullOrEmpty(x) || (x?.Length >= _min && x?.Length <= _max);

            return result ? ValidationResult.Success : new ValidationResult($"{context?.DisplayName} must contain between {_min} and {_max} Characters");
        }
    }
}
