using Xunit;

namespace HackerRankExercises.Arrays
{
    public class MinimumSwaps2Test
    {

        // TODO fails some test cases due to timeout, needs optimization
        static int minimumSwaps(int[] arr)
        {

            var swapsCount = 0;

            for(var i = 0; i < arr.Length; i++)
            {
                // the queue starts at number 1, not 0 like an array's index
                var supposedIndex = i + 1;
                var currentNumber = arr[i];

                if (supposedIndex == currentNumber) continue;

                // find the index where we must swap in order to put the current one in order
                for(var j = i +1; j < arr.Length; j++)
                {
                    // once we find the number that should go in the current index, swap it
                    if (arr[j] == supposedIndex)
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        swapsCount++;
                        // exit the j loop
                        continue;
                    }
                }

            }

            return swapsCount;
        }

        [Theory]
        [InlineData(new[] { 4, 3, 1, 2 }, 3)]
        [InlineData(new[] { 2, 3, 4, 1, 5 }, 3)]
        [InlineData(new[] { 1, 3, 5, 2, 4, 6, 7 }, 3)]
        public void Theory(int[] arr, int expectedResult)
        {
            var result = minimumSwaps(arr);
            Assert.Equal(expectedResult, result);
        }
    }
}
