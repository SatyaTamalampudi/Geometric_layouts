using GeometricLayouts.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricLayouts.Models
{
    public class Grid
    {
        public char Row { get; set; }

        public int Column { get; set; }

        [CharCount(1, 3)]
        public string RowColumn { get; set; }

        public Grid()
        { }

        public Grid(string rowColumn)
        {
            this.Row = rowColumn.FirstOrDefault();
            this.Column = int.Parse(rowColumn.Substring(1));
        }

        public int GetNumericRow()
        {
            int rowCharacterCode = this.Row;
            return rowCharacterCode - 65;
        }
    }
}
