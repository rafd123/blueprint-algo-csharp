using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    public static class Paint
    {
        public static void Floor(CellCoordinate startingCell, CellValue[][] blueprint)
        {
            var startingCellValue = GetCellValue(cell: startingCell, blueprint: blueprint);

            switch (startingCellValue)
            {
                case CellValue.BareFloor:
                case CellValue.PaintedFloor:
                    break;
                case CellValue.Wall:
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(startingCell),
                        message: "Invalid starting cell. The starting cell contains a wall.");
                default:
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(startingCell),
                        message: "Invalid starting cell. The starting cell is not within the blueprint.");
            }

            var stack = new Stack<CellCoordinate>();
            stack.Push(startingCell);
            while (stack.TryPop(out var cell))
            {
                if (!CanPaint(cell, blueprint))
                {
                    continue;
                }

                blueprint[cell.RowIndex][cell.ColumnIndex] = CellValue.PaintedFloor;

                foreach (var surroundingCell in GetEligibleSurroundingCells(cell, blueprint))
                {
                    stack.Push(surroundingCell);
                }
            }
        }

        private static IEnumerable<CellCoordinate> GetEligibleSurroundingCells(CellCoordinate cell, CellValue[][] blueprint)
        {
            var topLeft = new CellCoordinate(rowIndex: cell.RowIndex - 1, columnIndex: cell.ColumnIndex - 1);
            var topCenter = new CellCoordinate(rowIndex: cell.RowIndex - 1, columnIndex: cell.ColumnIndex);
            var topRight = new CellCoordinate(rowIndex: cell.RowIndex - 1, columnIndex: cell.ColumnIndex + 1);

            var middleLeft = new CellCoordinate(rowIndex: cell.RowIndex, columnIndex: cell.ColumnIndex - 1);
            var middleRight = new CellCoordinate(rowIndex: cell.RowIndex, columnIndex: cell.ColumnIndex + 1);

            var bottomLeft = new CellCoordinate(rowIndex: cell.RowIndex + 1, columnIndex: cell.ColumnIndex - 1);
            var bottomCenter = new CellCoordinate(rowIndex: cell.RowIndex + 1, columnIndex: cell.ColumnIndex);
            var bottomRight = new CellCoordinate(rowIndex: cell.RowIndex + 1, columnIndex: cell.ColumnIndex + 1);

            var topLeftCanPaint = CanPaint(topLeft, blueprint);
            var topCenterCanPaint = CanPaint(topCenter, blueprint);
            var topRightCanPaint = CanPaint(topRight, blueprint);

            var middleLeftCanPaint = CanPaint(middleLeft, blueprint);
            var middleRightCanPaint = CanPaint(middleRight, blueprint);

            var bottomLeftCanPaint = CanPaint(bottomLeft, blueprint);
            var bottomCenterCanPaint = CanPaint(bottomCenter, blueprint);
            var bottomRightCanPaint = CanPaint(bottomRight, blueprint);

            if (topLeftCanPaint && (topCenterCanPaint || middleLeftCanPaint))
            {
                yield return topLeft;
            }

            if (topCenterCanPaint)
            {
                yield return topCenter;
            }

            if (topRightCanPaint && (topCenterCanPaint || middleRightCanPaint))
            {
                yield return topRight;
            }

            if (middleLeftCanPaint)
            {
                yield return middleLeft;
            }

            if (middleRightCanPaint)
            {
                yield return middleRight;
            }

            if (bottomLeftCanPaint && (bottomCenterCanPaint || middleLeftCanPaint))
            {
                yield return bottomLeft;
            }

            if (bottomCenterCanPaint)
            {
                yield return bottomCenter;
            }

            if (bottomRightCanPaint && (bottomCenterCanPaint || middleRightCanPaint))
            {
                yield return bottomRight;
            }
        }

        private static bool CanPaint(CellCoordinate cell, CellValue[][] blueprint)
        {
            var cellValue = GetCellValue(cell, blueprint);
            return cellValue != null &&
                   cellValue != CellValue.Wall &&
                   cellValue != CellValue.PaintedFloor;
        }

        private static CellValue? GetCellValue(CellCoordinate cell, CellValue[][] blueprint)
        {
            if (cell.RowIndex < 0 || cell.ColumnIndex < 0 || cell.RowIndex > blueprint.Length - 1)
            {
                return null;
            }

            var row = blueprint[cell.RowIndex];

            return cell.ColumnIndex < row.Length ? (CellValue?)row[cell.ColumnIndex] : null;
        }
    }
}
