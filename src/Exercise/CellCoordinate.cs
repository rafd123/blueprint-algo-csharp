using System;

namespace Exercise
{
    public struct CellCoordinate
    {
        public CellCoordinate(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public int RowIndex { get; }

        public int ColumnIndex { get; }
    }
}