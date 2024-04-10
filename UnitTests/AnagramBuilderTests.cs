using Files;
using NUnit.Framework;
using System.IO;
using Moq;
using System.Collections.Generic;
using AnagramFinder;
using System;

namespace UnitTests
{
    public class AnagramBuilderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetWordsList_WithInvalidFilePath_ShouldThrowArgumentNullException()
        {
            IAnagramBuilder anagramBuilder = new AnagramBuilder();
            IFileProvider fileProvider = new FileProvider();

            Assert.Throws<ArgumentNullException>(() => anagramBuilder.GetWordsList("", fileProvider));
        }

        [Test]
        public void GetWordsList_WithSomeFilePathAndValidProvider_ShouldReturnValidStringList()
        {
            List<string> strCollection = new List<string>() { "aa", "bb", "cc" };
            // Arrange
            var mockFileProvider = new Mock<IFileProvider>();
            mockFileProvider.Setup(provider => provider.LoadFile(It.IsAny<string>()))
              .Returns(new List<string>(strCollection) );

            IAnagramBuilder anagramBuilder = new AnagramBuilder();
            // Act and Assert
            CollectionAssert.AreEqual(strCollection,anagramBuilder.GetWordsList("test", mockFileProvider.Object));
        }

        [Test]
        public void BuildLargestAnagramSet_WithInvalidFilePath_ShouldThrowArgumentNullException()
        {
            IAnagramBuilder anagramBuilder = new AnagramBuilder();
            IFileProvider fileProvider = new FileProvider();

            Assert.Throws<ArgumentNullException>(() => anagramBuilder.BuildLargestAnagramSet("", fileProvider));
        }

        [Test]
        public void BuildLargestAnagramSet_WithSomeFilePathAndValidProvider_ShouldReturnValidStringList()
        {
            List<string> wordsCollection = new List<string>() { "aa", "bb", "cc", "anagramabc", "anagrambca", "anagramcba" };

            List<string> anagramsCollection = new List<string>() { "anagramabc", "anagrambca", "anagramcba" };
            // Arrange
            var mockFileProvider = new Mock<IFileProvider>();
            mockFileProvider.Setup(provider => provider.LoadFile(It.IsAny<string>()))
              .Returns(new List<string>(wordsCollection));

            var mockAnagrams = new Mock<IAnagrams>();
            mockAnagrams.Setup(provider => provider.GetAnagramList())
              .Returns(new List<string>(anagramsCollection));


            IAnagramBuilder anagramBuilder = new AnagramBuilder();
            // Act and Assert
            CollectionAssert.AreEqual(anagramsCollection, anagramBuilder.BuildLargestAnagramSet("test", mockFileProvider.Object));
        }

    }
}