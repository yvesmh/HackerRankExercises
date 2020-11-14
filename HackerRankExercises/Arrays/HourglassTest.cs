using Xunit;
using System.Linq;
using System;

namespace HackerRankExercises.Arrays
{
    public class HourglassTest
    {

        static int hourglassSum(int[][] arr)
        {
            var maxGlassCount = int.MinValue;
            // the last valid start point for an hourglass is 3 positions before the end of the row
            for (var row = 0; row <= arr.Length - 3; row++)
            {
                for(var column = 0; column <= arr.Length - 3; column++)
                {
                    var hourglassCountAtCurrentPosition = GetHourGlassCountAt(row, column, arr);
                    if (hourglassCountAtCurrentPosition > maxGlassCount)
                    {
                        maxGlassCount = hourglassCountAtCurrentPosition;
                    }
                }
            }

            return maxGlassCount;
        }

        // assumes no index out of range will occur due to safeguards in main hourglassSum
        static int GetHourGlassCountAt(int row, int column, int[][] arr)
        {
            var firstRowCount = arr[row][column] + arr[row][column + 1] + arr[row][column + 2];
            var secondRowCount = arr[row + 1][column + 1];
            var thirdRowCount = arr[row + 2][column] + arr[row + 2][column + 1] + arr[row + 2][column + 2];

            return firstRowCount + secondRowCount + thirdRowCount;
        }

        [Theory]
        [InlineData(
@"1 1 1 0 0 0
0 1 0 0 0 0
1 1 1 0 0 0
0 0 2 4 4 0
0 0 0 2 0 0
0 0 1 2 4 0", 19)]
        [InlineData(
@"1 1 1 0 0 0
0 1 0 0 0 0
1 1 1 0 0 0
0 9 2 -4 -4 0
0 0 0 -2 0 0
0 0 -1 -2 -4 0", 13)]
        [InlineData(
@"-9 -9 -9 1 1 1
0 -9 0 4 3 2
-9 -9 -9 1 2 3
0 0 8 6 6 0
0 0 0 -2 0 0
0 0 1 2 4 0", 28)]
        public void Theory(string input, int expectedResult)
        {
            var twoDimensionArray = convertStringInputTo2DArray(input);
            var result = hourglassSum(twoDimensionArray);
            Assert.Equal(expectedResult, result);
        }

        private static int[][] convertStringInputTo2DArray(string input)
        {
            // split into rows
            var rows = input.Split("\n");
            
            int[][] twoDimensionArray = new int[rows.Length][];
            var index = 0;
            foreach(var row in rows)
            {
                twoDimensionArray[index++] = row
                    .Split(" ")
                    .Select(s => Convert.ToInt32(s))
                    .ToArray();

            }
            return twoDimensionArray;
        }

    }
}
