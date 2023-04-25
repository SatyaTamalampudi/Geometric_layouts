using GeometricLayouts.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeometricLayouts.Tests.Models
{
    public class CharCountAttributeTests
    {
        [Theory]
        [InlineData(1, 3, "tests", false)]
        [InlineData(1, 3, "t", true)]
        [InlineData(1, 3, "test", false)]
        [InlineData(1, 3, null, true)]
        public void ValidateStringCharCount(int min, int max, string value, bool expectedResult)
        {
            var attribute = new CharCountAttribute(min, max);

            var result = attribute.IsValid(value);

            Assert.Equal(expectedResult, result);
        }
    }
}
