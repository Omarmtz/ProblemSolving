using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolvingConsole.LongestWordInDictionary
{
    public static class LongestWordInDictionaryProblem
    {
        public static string GetLongestWord (string word, List<string> wordList)
        {
            var dictionary = BuildDictionary (wordList);
            var longestWord = string.Empty;

            foreach (var c in word)
            {
                if (!dictionary.ContainsKey (c))
                    continue;

                // Get Copy of matching word Lists
                var matchingWords = dictionary[c].ToList ();
                // Clean entire list because many keys in dict will be transfered to other key lists
                dictionary[c] = new List<MatchingWord> ();

                // Add +1 Index in each matching word and transfer to other key value in dict
                foreach (var match in matchingWords)
                {
                    match.Index++;
                    
                    // If the word is in W.Index == W.Length (String Found in Dictionary)
                    // then we can choose if is the maximun length word                    
                    if (match.Word.Length == match.Index)
                    {
                        // Check if is the max String
                        if (longestWord.Length < match.Word.Length)
                            longestWord = match.Word;
                    }
                    else
                    {
                        // Change Key access in dictionary 
                        if (!dictionary.ContainsKey (match.Word[match.Index]))
                        {
                            dictionary[match.Word[match.Index]] = new List<MatchingWord> ();
                        }
                        // Key is transferred to a new key in dictionary
                        dictionary[match.Word[match.Index]].Add (match);
                    }
                }
            }
            // Return Max Length word found
            return longestWord;
        }
        
        private static Dictionary<char, List<MatchingWord>> BuildDictionary (List<string> wordList)
        {
            var dictionary = new Dictionary<char, List<MatchingWord>> ();

            foreach (var word in wordList)
            {
                if (!dictionary.ContainsKey (word[0]))
                {
                    dictionary[word[0]] = new List<MatchingWord> ();
                }
                dictionary[word[0]].Add (new MatchingWord { Word = word, Index = 0 });
            }
            return dictionary;
        }

        private class MatchingWord
        {
            public int Index { get; set; }
            public string Word { get; set; }
        }
    }
}