using GeometricLayouts.Domain;
using GeometricLayouts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeometricLayouts.Tests.Domain
{
    public class GridCalculatorTests
    {
        private readonly ICalculator gridCalculator;

        public GridCalculatorTests()
        {
            gridCalculator = new Calculator();
        }

        [Fact]
        public void GetTriangleLocationForD2Test()
        {
            var traingle = new Triangle()
            {
                V1X = 10,
                V1Y = 30,
                V2X = 10,
                V2Y = 20,
                V3X = 0,
                V3Y = 30
            };
            var grid = gridCalculator.GetTriangleLocation(traingle);
            Assert.Equal(2, grid.Column);
            Assert.Equal('D', grid.Row);
            Assert.Equal("D2", grid.RowColumn);
        }

        [Fact]
        public void GetTriangleLocationForA12Test()
        {
            var traingle = new Triangle()
            {
                V1X = 60,
                V1Y = 60,
                V2X = 60,
                V2Y = 50,
                V3X = 50,
                V3Y = 60
            };
            var grid = gridCalculator.GetTriangleLocation(traingle);
            Assert.Equal(12, grid.Column);
            Assert.Equal('A', grid.Row);
            Assert.Equal("A12", grid.RowColumn);
        }


        [Fact]
        public void GetLeftTraingleVerticesWhenRowColumnPassedTest()
        {
            var grid = new Grid()
            {
                Column = 1,
                Row = 'F'
            };
            var vortices = gridCalculator.GetTriangleVertices(grid);
            Assert.Equal(3, vortices.Count);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 10);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 0);
        }

        [Fact]
        public void GetTraingleVerticesWhenSingleReferencePassedTest()
        {
            var grid = new Grid("F1");
            var vortices = gridCalculator.GetTriangleVertices(grid);
            Assert.Equal(3, vortices.Count);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 0);
            Assert.Contains(vortices, v => v.X == 0 && v.Y == 10);
            Assert.Contains(vortices, v => v.X == 10 && v.Y == 0);
        }

    }
}
