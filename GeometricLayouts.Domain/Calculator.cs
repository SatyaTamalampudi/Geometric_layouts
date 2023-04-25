using GeometricLayouts.Models;
using System;
using System.Collections.Generic;

namespace GeometricLayouts.Domain
{
    public class Calculator : ICalculator
    {
        private const int CELLSIZE = 10;

        public Grid GetTriangleLocation(Triangle triangle)
        {
            if (triangle.V1X < triangle.V3X)
            {
                return GetLeftTriangleLocation(triangle);
            }

            return GetRightTriangleLocation(triangle);
        }
        public Grid GetRightTriangleLocation(Triangle triangle)
        {
            var row = (triangle.V3Y - CELLSIZE) / CELLSIZE;

            var column = triangle.V1X * 2 / CELLSIZE;

            return new Grid { Row = (char)(70 - row), Column = column, RowColumn = $"{(char)(70 - row)}{column}" };
        }
        public Grid GetLeftTriangleLocation(Triangle triangle)
        {

            var row = triangle.V1Y / CELLSIZE;

            var column = (triangle.V1X + CELLSIZE) / CELLSIZE;

            return new Grid { Row = (char)(70 - row), Column = column, RowColumn = $"{(char)(70 - row)}{column}" };
        }

        public List<Coordinates> GetTriangleVertices(Grid grid)
        {
            if (!string.IsNullOrEmpty(grid.RowColumn))
            {
                grid = new Grid(grid.RowColumn);
            }

            if (grid?.Column % 2 == 0)
            {
                return GetRightTriangleVertices(grid);
            }
            else
            {
                return GetLeftTriangleVertices(grid);
            }
        }


        private List<Coordinates> GetLeftTriangleVertices(Grid grid)
        {
            var coordinates = new List<Coordinates>();


            var leftX = ((grid.Column - 1) * CELLSIZE) / 2;
            var topLeftY = Math.Abs((grid.GetNumericRow() - 5)) * CELLSIZE + CELLSIZE;
            var leftY = Math.Abs((grid.GetNumericRow() - 5)) * CELLSIZE;
            var bottomRightX = leftX + CELLSIZE;

            coordinates.Add(new Coordinates { X = leftX, Y = leftY });
            coordinates.Add(new Coordinates { X = leftX, Y = topLeftY });
            coordinates.Add(new Coordinates { X = bottomRightX, Y = leftY });
            return coordinates;
        }

        private List<Coordinates> GetRightTriangleVertices(Grid grid)
        {
            var coordinates = new List<Coordinates>();

            var topLeftX = ((grid.Column / 2) - 1) * CELLSIZE;
            var rightY = Math.Abs((grid.GetNumericRow() - 5)) * CELLSIZE + CELLSIZE;
            var rightX = topLeftX + CELLSIZE;
            var bottomRightY = rightY - CELLSIZE;

            coordinates.Add(new Coordinates { X = rightX, Y = rightY });
            coordinates.Add(new Coordinates { X = rightX, Y = bottomRightY });
            coordinates.Add(new Coordinates { X = topLeftX, Y = rightY });

            return coordinates;
        }


    }
}
