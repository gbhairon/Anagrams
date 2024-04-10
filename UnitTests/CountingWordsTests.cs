
using Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using LinqQueries;


namespace UnitTests
{
    public class CountingWordsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetWordCountAtoZ_WithEmptyWordsListPassed_ShouldReturnArgumentException()
        {
            // Arrange
            CountingWords cntWords = new CountingWords();
            // Act and Assert
            Assert.Throws<ArgumentException>(() =>  cntWords.GetWordCountAtoZ(new List<string>() { }));
        }

        [Test]
        public void GetWordCountAtoZ_WithValidWordsListPassed_ShouldReturnRelevantDictionaryWithCountOfWords()
        {
            // Arrange
            CountingWords cntWords = new CountingWords();
            // Act 
            var prefixCounts = cntWords.GetWordCountAtoZ(new List<string>() { "abacus","bravo", "brave","charlie","cat","canter","Delta"});
            // Assert
            if (prefixCounts.TryGetValue('a',out int valueCount))
            {
                Assert.AreEqual(1, valueCount);
            }
            if (prefixCounts.TryGetValue('b', out valueCount))
            {
                Assert.AreEqual(2, valueCount);
            }
            if (prefixCounts.TryGetValue('c', out valueCount))
            {
                Assert.AreEqual(3, valueCount);
            }
            if (prefixCounts.TryGetValue('d', out  valueCount))
            {
                Assert.AreEqual(1, valueCount);
            }
            if (prefixCounts.TryGetValue('e', out  valueCount))
            {
                Assert.AreEqual(0, valueCount);
            }

        }
    }
}

