
using Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using LinqQueries;


namespace UnitTests
{
    public class DistinctWordsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetLongestDistinctWord_WithEmptyWordsListPassed_ShouldReturnArgumentException()
        {
            // Arrange
            DistinctWords distinctWords = new DistinctWords();
            // Act and Assert
            Assert.Throws<ArgumentException>(() => distinctWords.GetLongestDistinctWord(new List<string>() { }));
        }

        [Test]
        public void GetWordCountAtoZ_WithValidWordsListPassed_ShouldReturnRelevantDictionaryWithCountOfWords()
        {
            // Arrange
            DistinctWords distinctWords = new DistinctWords();
            // Act 
            var longestWord = distinctWords.GetLongestDistinctWord(new List<string>() { "abacus","bravo", "brave","charlie","cat","canter","Delta"});
            // Assert
            Assert.AreEqual("charlie", longestWord);
        }
    }
}

