using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HackerRankExercises.StringManipulation
{
    public class AlternatingCharacters
    {
        static int alternatingCharacters(string s)
        {
            var lastAdjacentCharacter = char.MinValue;
            var charactersToDelete = 0;

            foreach(var character in s.ToCharArray())
            {
                if (character == lastAdjacentCharacter)
                {
                    charactersToDelete++;
                }
                lastAdjacentCharacter = character;
            }

            return charactersToDelete;
        }

        [Theory]
        [InlineData("AAAA", 3)]
        [InlineData("BBBBB", 4)]
        [InlineData("ABABABAB", 0)]
        [InlineData("BABABA", 0)]
        [InlineData("AAABBB", 4)]
        [InlineData("AAABBBAABB", 6)]
        [InlineData("AABBAABB", 4)]
        [InlineData("ABABABAA", 1)]
        [InlineData("ABBABBAA", 3)]
        public void Theory(string input, int expectedResult)
        {
            var result = alternatingCharacters(input);
            Assert.Equal(expectedResult, result);
        }
    }
}
