using System.Linq;
using Xunit;

namespace HackerRankExercises
{
    public class RepeatedStringTest
    {
        static long repeatedString(string stringToRepeat, long numberOfCharacters)
        {

            // rounded down number of times to repeat the string
            var numberOfTimesToRepeat = numberOfCharacters / stringToRepeat.Length;
            // remainder to go to reach the number of characters
            var remainder = numberOfCharacters % stringToRepeat.Length;

            var numberOfAsWithinStringtoRepeat = stringToRepeat
                .ToCharArray()
                .Count(x => x == 'a');

            var numberOfAsWithinRemainder =
                stringToRepeat.Substring(0, (int)remainder)
                .ToCharArray()
                .Count(x => x == 'a');

            return (numberOfAsWithinStringtoRepeat * numberOfTimesToRepeat) + numberOfAsWithinRemainder;

        }

        [Theory]
        [InlineData("aba", 10, 7)]
        [InlineData("a", 1000000000000, 1000000000000)]
        public void Theory(string s, long n, long expectedResult)
        {
            var result = repeatedString(s, n);
            Assert.Equal(expectedResult, result);
        }
    }
}
