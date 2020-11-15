using Xunit;

namespace HackerRankExercises.Arrays
{
    public class LeftRotationTest
    {
        // this one failed test cases 8 and 9 due to timeout
        static int[] rotLeftBruteForce(int[] arrayToRotate, int rotationCount)
        {
            var rotated = arrayToRotate;
            for(var i = 0; i < rotationCount; i++)
            {
                rotated = rotateOnce(rotated);
            }
            return rotated;
        }

        static int[] rotLeft(int[] arrayToRotate, int rotationCount)
        {
            var arrayLength = arrayToRotate.Length;
            var rotatedArray = new int[arrayLength];
            for(var i = 0; i < arrayLength; i++)
            {
                // calculate the new position using mod
                var newLocation = (i + (arrayLength - rotationCount)) % arrayLength;
                rotatedArray[newLocation] = arrayToRotate[i];
            }

            return rotatedArray;
        }

        static int[] rotateOnce(int[] array)
        {
            var rotated = new int[array.Length];
            // fill up all the way up until the second to last from the original
            for(var i = 0; i <= array.Length -2; i++)
            {
                rotated[i] = array[i + 1];
            }

            // put the first element of the original at the end of the rotated array
            rotated[array.Length - 1] = array[0];
            return rotated;
        }


        [Theory]
        [InlineData(new [] { 1, 2, 3, 4, 5 }, 4, new [] { 5, 1, 2, 3, 4 })]
        [InlineData(new[] { 41, 73, 89, 7, 10, 1, 59, 58, 84, 77, 77, 97, 58, 1, 86, 58, 26, 10, 86, 51 }, 10, new[] { 77, 97, 58, 1, 86, 58, 26, 10, 86, 51, 41, 73, 89, 7, 10, 1, 59, 58, 84, 77 })]
        [InlineData(new[] { 33, 47, 70, 37, 8, 53, 13, 93, 71, 72, 51, 100, 60, 87, 97 }, 13, new[] { 87, 97, 33, 47, 70, 37, 8, 53, 13, 93, 71, 72, 51, 100, 60 })]
        public void Theory(int[] array, int rotationCount, int[] expectedResult)
        {
            var result = rotLeft(array, rotationCount);
            Assert.Equal(expectedResult, result);
        }


    }
}
