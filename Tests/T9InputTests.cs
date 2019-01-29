using ProblemSolvingConsole.T9Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Tests
{
    public class T9InputTests
    {
        [Fact]
        public void T9Test_Word_Found()
        {
            var expectedWordList = new List<string> { "pay", "paw", "pax", "pbx", "ray", "raw", "rax", "say", "saw", "sax" };

            var listOfWords = File.ReadAllLines(@"T9Input\Words.txt").ToList();
            var t9InputCode = T9InputSystem.GetT9CodeString("raw");

            var results = T9InputSystem.GetMatchingWords(t9InputCode, listOfWords);

            Assert.Equal(results, expectedWordList);
        }
    }
}