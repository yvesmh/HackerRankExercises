using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace HackerRankExercises.HashTables
{
    public class SherlockAndAnagramsTest
    {
        static int sherlockAndAnagrams(string s)
        {
            var substringMap = new Dictionary<string, int>();
            var anagramCount = 0;

            for(var i = 0; i < s.Length; i++)
            {
                for(var j = i; j < s.Length; j++)
                {
                    // form a combination ordered alphabetically
                    var substringLength = j - i + 1;
                    var orderedCharArray = s.Substring(i, substringLength)
                        .ToCharArray()
                        .OrderBy(x => x)
                        .ToArray();

                    var orderedSubstring = new string(orderedCharArray);

                    substringMap.TryGetValue(orderedSubstring, out int currentCount);

                    substringMap[orderedSubstring] = ++currentCount;

                }
            }

            foreach(var entry in substringMap)
            {
                if (entry.Value > 1)
                {
                    // remove duplicates
                    anagramCount += (entry.Value * (entry.Value - 1)) / 2;
                }
            }

            return anagramCount;

        }

        [Theory]
        [InlineData("abba", 4)]
        [InlineData("abcd", 0)]
        [InlineData("ifailuhkqq", 3)]
        [InlineData("kkkk", 10)]
        [InlineData("cdcd", 5)]
        public void Theory(string input, int expectedResult)
        {
            var result = sherlockAndAnagrams(input);
            Assert.Equal(expectedResult, result);
        }
    }
}
