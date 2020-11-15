using System.Linq;
using Xunit;
using System;

namespace HackerRankExercises.HashTables
{
    public class RansomNotesTest
    {
        static bool checkMagazineForLocalDebugging(string[] magazine, string[] note)
        {
            var magazineHashmap = magazine
                .GroupBy(x => x)
                .ToDictionary(k => k.Key, v => v.Count());

            foreach(var word in note)
            {
                if (magazineHashmap.ContainsKey(word) && magazineHashmap[word] > 0)
                {
                    magazineHashmap[word]--;
                }
                // if the word is not in the magazine or ran out of words,
                // the ransom note cannot be completed, can return early
                else return false;
            }

            return true;

        }

        static void checkMagazine(string[] magazine, string[] note)
        {
            var result = checkMagazineForLocalDebugging(magazine, note);

            var output = result ? "Yes" : "No";

            Console.WriteLine(output);
        }

        [Theory]
        [InlineData("give me one grand today night", "give one grand today", true)]
        [InlineData("two times three is not four", "two times two is four", false)]
        [InlineData("ive got a lovely bunch of coconuts", "ive got some coconuts", false)]
        public void Theory(string magazine, string note, bool expectedResult)
        {
            var magazineArray = magazine.Split(" ");
            var noteArray = note.Split(" ");
            var result = checkMagazineForLocalDebugging(magazineArray, noteArray);

            Assert.Equal(expectedResult, result);
        }


    }
}
