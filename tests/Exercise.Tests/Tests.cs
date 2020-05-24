using System;
using System.Collections;
using NUnit.Framework;

namespace Exercise.Tests
{
    public class Tests
    {
        private static readonly IEnumerable ShouldPaintFloorTestCases = new[]
        {
            TestCase(
                testName: "Split floor plan",
                new CellCoordinate(rowIndex: 0, columnIndex: 0),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor,    CellValue.BareFloor,    CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor,    CellValue.BareFloor,    CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor,    CellValue.BareFloor,    CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor,    CellValue.BareFloor,    CellValue.Wall, CellValue.BareFloor },
                },
                expectedBlueprint: new []
                {
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.Wall, CellValue.BareFloor },
                }),

            TestCase(
                testName: "Opening in wall",
                new CellCoordinate(rowIndex: 0, columnIndex: 0),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor },
                },
                expectedBlueprint: new []
                {
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.Wall,         CellValue.PaintedFloor },
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor },
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.Wall,         CellValue.PaintedFloor },
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.Wall,         CellValue.PaintedFloor },
                }),

            TestCase(
                testName: "Outside \"elevator shaft\"",
                new CellCoordinate(rowIndex: 4, columnIndex: 2),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.Wall,      CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.Wall,      CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor },
                },
                expectedBlueprint: new []
                {
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor },
                    new [] { CellValue.PaintedFloor, CellValue.Wall,         CellValue.Wall,         CellValue.Wall,         CellValue.PaintedFloor },
                    new [] { CellValue.PaintedFloor, CellValue.Wall,         CellValue.BareFloor,    CellValue.Wall,         CellValue.PaintedFloor },
                    new [] { CellValue.PaintedFloor, CellValue.Wall,         CellValue.Wall,         CellValue.Wall,         CellValue.PaintedFloor },
                    new [] { CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor, CellValue.PaintedFloor },
                }),

            TestCase(
                testName: "Inside \"elevator shaft\"",
                new CellCoordinate(rowIndex: 2, columnIndex: 2),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.Wall,      CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.Wall,      CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor },
                },
                expectedBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor,    CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.Wall,         CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.PaintedFloor, CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.Wall,         CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor,    CellValue.BareFloor, CellValue.BareFloor },
                }),

            TestCase(
                testName: "Inside diagonal walls",
                new CellCoordinate(rowIndex: 2, columnIndex: 2),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall,      CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor },

                },
                expectedBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor,    CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall,         CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.Wall,      CellValue.PaintedFloor, CellValue.Wall,      CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall,         CellValue.BareFloor, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.BareFloor,    CellValue.BareFloor, CellValue.BareFloor },
                }),

            TestCase(
                testName: "Start cell outside of blueprint 1",
                new CellCoordinate(rowIndex: 100, columnIndex: 100),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                },
                expectedBlueprint: null),

            TestCase(
                testName: "Start cell outside of blueprint 2",
                new CellCoordinate(rowIndex: -100, columnIndex: 100),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                },
                expectedBlueprint: null),

            TestCase(
                testName: "Start cell outside of blueprint 3",
                new CellCoordinate(rowIndex: -100, columnIndex: -100),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                },
                expectedBlueprint: null),

            TestCase(
                testName: "Start cell outside of blueprint 4",
                new CellCoordinate(rowIndex: 100, columnIndex: -100),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                },
                expectedBlueprint: null),

            TestCase(
                testName: "Start cell is wall",
                new CellCoordinate(rowIndex: 2, columnIndex: 2),
                initialBlueprint: new []
                {
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                    new [] { CellValue.BareFloor, CellValue.BareFloor, CellValue.Wall, CellValue.BareFloor },
                },
                expectedBlueprint: null),
        };

        [Test, TestCaseSource(nameof(ShouldPaintFloorTestCases))]
        public void ShouldPaintFloor(
            CellCoordinate startingCell,
            CellValue[][] initialBlueprint,
            CellValue[][]? expectedBlueprint)
        {
            if (expectedBlueprint == null)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                    Paint.Floor(
                        startingCell: startingCell,
                        blueprint: initialBlueprint));
            }
            else
            {
                Paint.Floor(startingCell: startingCell, blueprint: initialBlueprint);

                for (var rowIndex = 0; rowIndex < expectedBlueprint.Length; ++rowIndex)
                {
                    var actualRow = initialBlueprint[rowIndex];
                    var expectedRow = expectedBlueprint[rowIndex];
                    for (var columnIndex = 0; columnIndex < expectedRow.Length; ++columnIndex)
                    {
                        Assert.AreEqual(
                            expectedRow[columnIndex],
                            actualRow[columnIndex],
                            $"Unexpected value at row {rowIndex}, column {columnIndex}");
                    }
                }
            }
        }

        private static TestCaseData TestCase(
            string testName,
            CellCoordinate startingCell,
            CellValue[][] initialBlueprint,
            CellValue[][]? expectedBlueprint)
        {
            var testCaseData = new TestCaseData(
                startingCell,
                initialBlueprint,
                expectedBlueprint)
            {
                TestName = testName
            };

            return testCaseData;
        }
    }
}