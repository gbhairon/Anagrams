using AnagramFinder;
using Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    public class AnagramsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Anagrams_WithEmptyWordsListPassedToConstructor_ShouldReturnArgumentException()
        {
            // Arrange
            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Anagrams(new List<string>() { } ));
        }

        [Test]
        public void Anagrams_WithNonEmptyWordsListPassedToConstructor_ShouldNotReturnArgumentException()
        {
            // Arrange
            // Act and Assert
            Assert.DoesNotThrow(() => new Anagrams(new List<string>() { "Test"}));
        }

        [Test]
        public void SetSortedValueForWord_WithEmptyWord_ShouldReturnEmptyString()
        {
            // Arrange
            IAnagrams anagrams = new Anagrams(new List<string>() {"test" });
            // Act and Assert
            Assert.AreEqual("", anagrams.SetSortedValueForWord(""));
        }

        [Test]
        public void SetSortedValueForWord_WithValidWord_ShouldReturnValidSortedString()
        {
            // Arrange
            IAnagrams anagrams = new Anagrams(new List<string>() { "test" });
            // Act and Assert
            Assert.AreEqual("abcde", anagrams.SetSortedValueForWord("ebcda"));
        }

        [Test]
        public void GetAnagramList_WithValidWordList_ShouldReturnValidLargestAnagramList()
        {
            // Arrange
            IAnagrams anagrams = new Anagrams(new List<string>() { "binary","please","asleep","brainy","silent","listen","sapele" });
            // Act and Assert
            CollectionAssert.AreEqual(new List<string>() { "asleep", "please", "sapele" }, anagrams.GetAnagramList());
        }

        [Test]
        // Note that we would need clarification if the behaviour here is to be different than returning some values in the case of a tie
        public void GetAnagramList_WithValidWordListButATie_ShouldReturnONeOfTheAnagramsInTheList()
        {
            // Arrange
            IAnagrams anagrams = new Anagrams(new List<string>() { "binary", "please", "asleep", "brainy", "silent", "listen" });
            // Act and Assert
            Assert.AreEqual(2, anagrams.GetAnagramList().Count);
        }
    }
}
