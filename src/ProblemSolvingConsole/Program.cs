using System;
using System.Collections.Generic;
using ProblemSolvingConsole.LongestWordInDictionary;

namespace ProblemSolvingConsole
{
    class Program
    {
        static void Main (string[] args)
        {
            var wListA = new List<string> { "able", "ale", "apple", "bale", "kangaroo" };
            var wordA = "abppplee";

            var wListB = new List<string> { "ale", "apple", "monkey", "plea" };
            var wordB = "abpcplea";

            System.Console.WriteLine (LongestWordInDictionaryProblem.GetLongestWord (wordA, wListA));
            System.Console.WriteLine (LongestWordInDictionaryProblem.GetLongestWord (wordB, wListB));
        }
    }
}