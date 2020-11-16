using System.Collections.Generic;
using Xunit;

namespace HackerRankExercises
{
    public class SlowestKeyPressTest
    {

        public static char slowestKey(List<List<int>> keyTimes)
        {
            var maxTime = int.MinValue;
            var longestEncodedKey = int.MinValue;

            foreach(var keyTime in keyTimes)
            {
                var encodedKey = keyTime[0];
                var time = keyTime[1];
                
                if (time > maxTime)
                {
                    maxTime = time;
                    longestEncodedKey = encodedKey;
                }
            }

            // since 'a' is 97 decimal in ascii table

            var asciiDecimal = 97 + longestEncodedKey;
            
            return (char)asciiDecimal;

        }

        [Fact]
        public void TestCase1()
        {
            var twoDimensionArray = new List<List<int>>();
            twoDimensionArray.Add(new List<int>(new[] { 0, 20 }));
            twoDimensionArray.Add(new List<int>(new[] { 1, 2 }));
            twoDimensionArray.Add(new List<int>(new[] { 3, 4 }));
            twoDimensionArray.Add(new List<int>(new[] { 5, 3 }));
            var result = slowestKey(twoDimensionArray);

            Assert.Equal('a', result);
        }

        [Fact]
        public void TestCase2()
        {
            var twoDimensionArray = new List<List<int>>();
            twoDimensionArray.Add(new List<int>(new[] { 0, 1 }));
            twoDimensionArray.Add(new List<int>(new[] { 1, 2 }));
            twoDimensionArray.Add(new List<int>(new[] { 3, 4 }));
            twoDimensionArray.Add(new List<int>(new[] { 3, 8 }));
            twoDimensionArray.Add(new List<int>(new[] { 5, 3 }));
            var result = slowestKey(twoDimensionArray);

            Assert.Equal('d', result);
        }

        [Fact]
        public void TestCase3()
        {
            var twoDimensionArray = new List<List<int>>();
            twoDimensionArray.Add(new List<int>(new[] { 0, 1 }));
            twoDimensionArray.Add(new List<int>(new[] { 1, 2 }));
            twoDimensionArray.Add(new List<int>(new[] { 3, 4 }));
            twoDimensionArray.Add(new List<int>(new[] { 3, 8 }));
            twoDimensionArray.Add(new List<int>(new[] { 5, 3 }));
            twoDimensionArray.Add(new List<int>(new[] { 25, 10 }));
            var result = slowestKey(twoDimensionArray);

            Assert.Equal('z', result);
        }
    }
}
