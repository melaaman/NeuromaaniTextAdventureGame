using NUnit.Framework;
using System;
using NeuromaaniTextAdventureGame.FileManager;

namespace NeuromaaniTextAdventureGame.Tests.FileManager.Tests
{
    [TestFixture]
   public class FileReaderTests
    {
        FileReader reader;

        [Test] 

        public void ReadToEndAndClose_FileHasMultipleRows_ReturnTrue()
        {
            reader = new FileReader();
            var result = reader.ReadToEndAndClose("test1.txt");
            Assert.AreEqual("Testi\r\nRivi 2", result);
        }

        [Test]

        public void ReadToEndAndClose_FileHasOneRow_ReturnTrue()
        {
            reader = new FileReader();
            var result = reader.ReadToEndAndClose("test2.txt");
            Assert.AreEqual("Testi", result);
        }

        [Test]

        public void ReadToEndAndClose_FileDoesntExist_ReturnFalse()
        {
            reader = new FileReader();
            Assert.Throws<Exception>(() => reader.ReadToEndAndClose("fakeFile.txt"));
        }

        [Test] 

        public void GetTextRows_TwoRowText_ReturnTrue()
        {
            reader = new FileReader();
            var result = reader.ConvertTextToArray("Hei\r\nOlen Gereg").Length;
            Assert.AreEqual(2, result);
        }

        [Test]
        public void GetTextRows_OneRowText_ReturnTrue()
        {
            reader = new FileReader();
            var result = reader.ConvertTextToArray("Hei").Length;
            Assert.AreEqual(1, result);
        }

        [Test]

        public void GetTextChapterFromFile_TwoChaptersInFile_ReturnTrue()
        {
            reader = new FileReader();
            var result = reader.GetTextChapterFromFile("test3.txt", 1);
            Assert.AreEqual("Toka kappale\r\nToka", result);
        }
    }
}
