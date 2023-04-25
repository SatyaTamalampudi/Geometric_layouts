using GeometricLayouts.Models.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GeometricLayouts.Models
{
    [ExcludeFromCodeCoverage]
    public class Coordinates
    {
        [GreaterThanZero]
        public int X { get; set; }

        [GreaterThanZero]
        public int Y { get; set; }
    }
}
