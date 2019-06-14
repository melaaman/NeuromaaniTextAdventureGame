using FakeItEasy;
using NUnit.Framework;
using System;
using NeuromaaniTextAdventureGame.FileManager;

namespace NeuromaaniTextAdventureGame.Tests.FileManager.Tests
{
    [TestFixture]
    public class FileVerifierTests
    {
        FileVerifier fileVerifier;

        [Test]
        public void IsValidFileName_FileIsCorrectFormat_ReturnTrue()
        {
            fileVerifier = new FileVerifier();
            var result = fileVerifier.IsValidFileName("testi.txt");
            Assert.AreEqual(true, result);
        }

        [TestCase("")]
        [TestCase("testi.xxx")]
        [TestCase("testi")]

        public void ReadFile_IncorrectFileName_ThrowException(string fileName)
        {

            Assert.Throws<Exception>(() => fileVerifier.IsValidFileName(fileName));

        }
    }
}
