using GeometricLayouts.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeometricLayouts.Tests.Models
{
    public class GreaterThanZeroAttributeTests
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(10, true)]
        [InlineData(0, false)]
        [InlineData(-4, false)]
        public void Validate_GreaterThanZeroAttribute(int value, bool expectedResult)
        {
            var validation = new GreaterThanZeroAttribute();
            var actualResult = validation.IsValid(value);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
