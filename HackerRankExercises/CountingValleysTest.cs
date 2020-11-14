using System.Linq;
using Xunit;

namespace HackerRankExercises
{
    public class CountingValleysTest
    {

        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         */

        public static int CountingValleys(int steps, string path)
        {
            var currentLevel = 0;
            var valleysCount = 0;

            var convertedPath = path
                .ToCharArray()
                .Select(ConvertStepDescriptionToAltitude);

            foreach (var step in convertedPath)
            {
                currentLevel += step;

                if (currentLevel == 0 && step == 1)
                {
                    valleysCount++;
                }
            }

            return valleysCount;

        }

        private static int ConvertStepDescriptionToAltitude(char step)
        {
            switch(step)
            {
                case 'u':
                case 'U': return 1;
                case 'd':
                case 'D': return -1;
                default: return 0;
            }
        }


        [Theory]
        [InlineData("UUU", 0)]
        [InlineData("DDD", 0)]
        [InlineData("DUU", 1)]
        [InlineData("UDDDUDUUU", 1)] // sample from HackerRank
        [InlineData("DUDDUU", 2)]
        public void Theory(string path, int expectedResult)
        {
            var result = CountingValleys(path.Length, path);
            Assert.Equal(expectedResult, result);
        }
    }
}
