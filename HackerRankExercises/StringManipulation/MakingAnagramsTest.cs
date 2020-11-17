using System.Linq;
using Xunit;
using System;

namespace HackerRankExercises.StringManipulation
{
    public class MakingAnagramsTest
    {
        static int makeAnagram(string a, string b)
        {
            var characterRemovalsNeeded = 0;

            var aMap = a.ToCharArray()
                .GroupBy(x => x)
                .ToDictionary(k => k.Key, v => v.Count());

            var bMap = b.ToCharArray()
                .GroupBy(x => x)
                .ToDictionary(k => k.Key, v => v.Count());

            foreach (var character in a.ToCharArray())
            {
                // get character count from both maps
                aMap.TryGetValue(character, out int characterCountA);
                bMap.TryGetValue(character, out int characterCountB);

                // zero them out so they aren't counted in the B iteration
                aMap[character] = 0;
                bMap[character] = 0;

                characterRemovalsNeeded += Math.Abs(characterCountA - characterCountB);
            }

            // for characters that were only in B but not in A
            foreach (var character in b.ToCharArray())
            {
                aMap.TryGetValue(character, out int characterCountA);
                bMap.TryGetValue(character, out int characterCountB);

                aMap[character] = 0;
                bMap[character] = 0;

                characterRemovalsNeeded += Math.Abs(characterCountA - characterCountB);
            }

            return characterRemovalsNeeded;

        }

        [Theory]
        [InlineData("cde", "abc", 4)]
        [InlineData("fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke", 30)]
        [InlineData("showman", "woman", 2)]
        public void Theory(string a, string b, int expectedResult)
        {
            var result = makeAnagram(a, b);
            Assert.Equal(expectedResult, result);
        }

    }
}
