# HackerRank Exercises

My solutions to hacker rank exercises using C# and XUnit to verify my solution using sample test data before submitting my answer.


My method of solving these exercises is to click "Download sample test cases". The downloaded zip file contains the inputs and outputs of some test cases, which I convert into XUnit's `[Theory]` with `[InlineData]`.

## Example

For this example, we'll use the problem  [HashTables - Ransom Note](https://www.hackerrank.com/challenges/ctci-ransom-note/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps)

The downloaded test cases contain the following data:

Input00.txt
```
6 4
give me one grand today night
give one grand today
```

Input20.txt
```
6 5
two times three is not four
two times two is four
```

Input21.txt
```
7 4
ive got a lovely bunch of coconuts
ive got some coconuts
```


Output00.txt
```
Yes
```

Output20.txt
```
No
```

Output21.txt
```
No
```

Those test cases's inputs and outputs can be translated into the following xUnit code:

```cs
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
```

Once I write the solution that passes those tests locally, I submit my answer in HackerRank.

Note that some HackerRank problems may contain sample data that passes locally, but may not pass all the test cases once the "Submit" button is hit, which can happen when the solution is either slow (brute force solutions) or doesn't take into account some edge cases.
