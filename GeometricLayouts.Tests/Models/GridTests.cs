using GeometricLayouts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeometricLayouts.Tests.Models
{
    public class GridTests
    {
        [Theory]
        [InlineData("E1", 'E', 1)]
        [InlineData("A4", 'A', 4)]
        public void GetRowColumnTest(string rowColumn, char row, int column)
        {
            var grid = new Grid(rowColumn);
            Assert.Equal(row, grid.Row);
            Assert.Equal(column, grid.Column);
        }

        [Fact]
        public void GetRowColumnThrowsColumnArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new Grid(""); });
        }

        [Fact]
        public void GetRowColumnThrowsRowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { new Grid(null); });
        }

        [Theory]
        [InlineData('E', 4)]
        [InlineData('A', 0)]
        [InlineData('@', -1)]
        public void GetNumericRowTest(char row, int rowNumber)
        {
            var result = new Grid()
            {
                Row = row
            }.GetNumericRow();

            Assert.Equal(rowNumber, result);
        }
    }
}
