using Xunit;

namespace HackerRankExercises
{
    public class JumpingOnCloudsTest
    {
        const int BadCloud = 1;
        // Complete the jumpingOnClouds function below.
        static int jumpingOnClouds(int[] c)
        {
            var jumpCount = 0;
            var currentCloudIndex = 0;

            // iterate until we're 1 cloud behind the last one
            while (currentCloudIndex <= c.Length -2)
            {
                var nextCloud = c[currentCloudIndex + 1];
                // if the next cloud is a bad cloud, and assuming
                // the game can always be won, we must absolutely jump over the bad cloud
                if (nextCloud == BadCloud)
                {
                    currentCloudIndex += 2;
                    jumpCount++;
                    continue;
                }

                // prevent IndexOutOfRange by checking if a skip jump would put us beyond the end
                // in that case, we know we can return right after a non-skip jump
                if (currentCloudIndex + 2 >= c.Length)
                {
                    return jumpCount + 1;
                }

                // if the next cloud isn't a good cloud, we need to make sure that
                // the second next cloud isn't a bad cloud preventing us from a cloud skip
                var secondNextCloud = c[currentCloudIndex + 2];

                if (secondNextCloud == BadCloud)
                {
                    currentCloudIndex += 1;
                }
                else
                {
                    currentCloudIndex += 2;
                }
                jumpCount++;

            }

            return jumpCount;

        }

        [Theory]
        [InlineData(new [] { 0, 0, 1, 0, 0, 1, 0 }, 4)]
        [InlineData(new[] { 0, 0, 0, 1, 0, 0 }, 3)]
        [InlineData(new[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }, 5)]
        [InlineData(new[] { 0, 0, 1, 0, 0, 1, 0, 0}, 5)]

        public void Theory(int[] input, int expectedResult)
        {
            var result = jumpingOnClouds(input);
            Assert.Equal(expectedResult, result);
        }
    }
}
