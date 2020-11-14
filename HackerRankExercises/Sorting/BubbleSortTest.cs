using System;
using Xunit;

namespace HackerRankExercises.Sorting
{
    public class BubbleSortTest
    {
        // Complete the countSwaps function below.
        static int countSwapsForLocalTesting(int[] a)
        {
            var n = a.Length;
            var swapCount = 0;

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        var temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swapCount++;
                        //swap(a[j], a[j + 1]);
                    }
                }

            }

            return swapCount;
        }

        // for submitting
        static void countSwaps(int[] a)
        {
            var n = a.Length;
            var swapCount = 0;

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        var temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swapCount++;
                        //swap(a[j], a[j + 1]);
                    }
                }

            }

            Console.WriteLine($"Array is sorted in {swapCount} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[a.Length - 1]}");

        }

        [Theory]
        [InlineData(new [] { 1, 2, 3 }, 0)]
        [InlineData(new[] { 3, 2, 1 }, 3)]
        [InlineData(new[] { 4, 2, 3, 1 }, 5)]
        public void Theory(int[] a, int expectedResult)
        {
            var result = countSwapsForLocalTesting(a);
            countSwaps(a);
            Assert.Equal(expectedResult, result);
        }
    }
}
