using Files;
using NUnit.Framework;
using System.IO;

namespace UnitTests
{
    public class FileProviderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadFile_WithEmptyFilePath_ShouldReturnFileNotFoundException()
        {
            // Arrange
            IFileProvider fileProvider = new FileProvider();
            // Act and Assert
            Assert.Throws<FileNotFoundException>(() => fileProvider.LoadFile(""));
        }
        [Test]
        public void LoadFile_WithInvalidFilePath_ShouldReturnFileNotFoundException()
        {
            // Arrange
            IFileProvider fileProvider = new FileProvider();
            // Act and Assert
            Assert.Throws<FileNotFoundException>(() => fileProvider.LoadFile("C:\\BadFilePath"));
        }
    }
}