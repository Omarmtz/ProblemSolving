using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolvingConsole.T9Input
{
    public static class T9InputSystem
    {
        public static List<string> GetMatchingWords(string numberCode, List<string> words)
        {
            var resultList = new List<string>();
            if (string.IsNullOrEmpty(numberCode))
            {
                return resultList;
            }

            var dictionary = BuildDictionary(words);

            for (int i = 0; i < numberCode.Length; i++)
            {
                var digit = numberCode[i];
                var matchingWords = dictionary[digit];

                //Clear Values
                dictionary[digit] = new List<DictionaryValue>();

                foreach (var match in matchingWords)
                {
                    if (match.Index == i && digit == GetT9Code(match.Word, match.Index))
                    {
                        match.Index++;
                    }

                    if (match.Index == numberCode.Length && match.Word.Length == numberCode.Length)
                    {
                        resultList.Add(match.Word);
                    }

                    var transferIndex = GetT9Code(match.Word, match.Index);

                    if (!dictionary.ContainsKey(transferIndex))
                    {
                        dictionary[transferIndex] = new List<DictionaryValue>();
                    }
                    dictionary[transferIndex].Add(match);
                }
            }

            return resultList;
        }

        private static Dictionary<char, List<DictionaryValue>> BuildDictionary(List<string> words)
        {
            var dictionary = new Dictionary<char, List<DictionaryValue>>();

            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }

                if (!dictionary.ContainsKey(GetT9Code(word, 0)))
                {
                    dictionary[GetT9Code(word, 0)] = new List<DictionaryValue>();
                }

                dictionary[GetT9Code(word, 0)].Add(new DictionaryValue
                {
                    Word = word
                });
            }

            return dictionary;
        }

        public static string GetT9CodeString(string word)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                result.Append(GetT9Code(word, i));
            }

            return result.ToString();
        }

        private static char GetT9Code(string word, int index)
        {
            index = index >= word.Length ? word.Length - 1 : index;

            if (word[index] == 'a' || word[index] == 'b' || word[index] == 'c')
            {
                return '2';
            }
            if (word[index] == 'd' || word[index] == 'e' || word[index] == 'f')
            {
                return '3';
            }
            if (word[index] == 'g' || word[index] == 'h' || word[index] == 'i')
            {
                return '4';
            }
            if (word[index] == 'j' || word[index] == 'k' || word[index] == 'l')
            {
                return '5';
            }
            if (word[index] == 'm' || word[index] == 'n' || word[index] == 'o')
            {
                return '6';
            }
            if (word[index] == 'p' || word[index] == 'q' || word[index] == 'r' || word[index] == 's')
            {
                return '7';
            }
            if (word[index] == 't' || word[index] == 'u' || word[index] == 'v')
            {
                return '8';
            }
            if (word[index] == 'w' || word[index] == 'x' || word[index] == 'y' || word[index] == 'z')
            {
                return '9';
            }
            if (word[index] == ' ')
            {
                return '0';
            }

            return '*';
        }
    }

    internal class DictionaryValue
    {
        public string Word { get; set; }
        public int Index { get; set; }
    }
}