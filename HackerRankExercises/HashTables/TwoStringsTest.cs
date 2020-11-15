using Xunit;
using System.Linq;

namespace HackerRankExercises.HashTables
{
    public class TwoStringsTest
    {
        static bool stringsShareCommonSubstring(string s1, string s2)
        {
            //  A substring may be as small as one character
            var charactersInFirst = s1.ToCharArray()
                // create a lookup by character, the value doesn't matter (0)
                .ToLookup(x => x, x => 0);
                

            foreach(var character in s2.ToCharArray())
            {
                // as long as 1 substring is found, we can return early
                if (charactersInFirst.Contains(character)) return true;
            }

            return false;
        }

        static string twoStrings(string s1, string s2)
        {
            var result = stringsShareCommonSubstring(s1, s2);
            return result ? "YES" : "NO";
        }

        [Theory]
        [InlineData("hello", "world", true)]
        [InlineData("hi", "world", false)]
        [InlineData("wouldyoulikefries", "abcabcabcabcabcabc", false)]
        [InlineData("hackerrankcommunity", "cdecdecdecde", true)]
        [InlineData("jackandjill", "wentupthehill", true)]
        [InlineData("writetoyourparents", "fghmqzldbc", false)]
        [InlineData("aardvark", "apple", true)]
        [InlineData("beetroot", "sandals", false)]
        public void Theory(string s1, string s2, bool expectedResult)
        {
            var result = stringsShareCommonSubstring(s1, s2);
            Assert.Equal(expectedResult, result);
        }
    }
}
