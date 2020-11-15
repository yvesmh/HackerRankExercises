using System;
using Xunit;

namespace HackerRankExercises.Arrays
{
    public class NewYearChaosTest
    {

        static int minimumBribesForLocalDebugging(int[] queue)
        {
            var bribesCount = 0;

            for (var i = 0; i < queue.Length; i++)
            {

                // the queue starts at number 1, not 0 like an array's index
                var supposedIndex = i + 1;
                var currentNumber = queue[i];

                // more than 2 bribes, can return early as "too chaotic"
                if ((currentNumber - supposedIndex) > 2)
                {
                    return -1;
                }

                // count number of people who passed the current person
                for (var j = Math.Max(0, queue[i] - 2); j < i; j++)
                {
                    if (queue[j] > queue[i])
                    {
                        bribesCount++;
                    }
                }

            }
            return bribesCount;

        }

        // HackerRank one is void and must print within method 
        static void minimumBribes(int[] queue)
        {
            var bribesCount = 0;

            for (var i = 0; i < queue.Length; i++)
            {

                // the queue starts at number 1, not 0 like an array's index
                var supposedIndex = i + 1;
                var currentNumber = queue[i];

                // more than 2 bribes, can return early as "too chaotic"
                if ((currentNumber - supposedIndex) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                // count number of people who passed the current person
                for (var j = Math.Max(0, queue[i] - 2); j < i; j++)
                {
                    if (queue[j] > queue[i])
                    {
                        bribesCount++;
                    }
                }

            }

            Console.WriteLine(bribesCount);
        }

        [Theory]
        [InlineData(new [] { 2, 1, 5, 3, 4 }, 3)]
        [InlineData(new[] { 2, 5, 1, 3, 4 }, -1)]
        [InlineData(new[] { 5, 1, 2, 3, 7, 8, 6, 4 }, -1)]
        [InlineData(new[] { 1, 2, 5, 3, 7, 8, 6, 4 }, 7)]
        [InlineData(new[] { 1, 2, 5, 3, 4, 7, 8, 6 }, 4)]
        public void Theory(int[] queue, int expectedResult)
        {
            var result = minimumBribesForLocalDebugging(queue);
            Assert.Equal(expectedResult, result);
        }
    }
}
