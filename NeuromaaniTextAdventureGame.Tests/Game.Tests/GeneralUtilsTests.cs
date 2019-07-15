using NeuromaaniTextAdventureGame.Game;
using NUnit.Framework;

namespace NeuromaaniTextAdventureGame.Tests.Game.Tests
{
    [TestFixture]
    public class GeneralUtilsTests
    {
        [TestCase("kahdeksa", "kahdeksa")]
        [TestCase("viisi", "viisi")]
        public void TruncateString_StringOfEightOrLessCharacters_ReturnTrue(string input, string output)
        {
            var result = GeneralUtils.TruncateString(input, 8);
            Assert.AreEqual(output, result);
        }

        [TestCase("kahdeksan", "kahdeks...")]
        [TestCase("viisitoista", "viisito...")]
        public void TruncateString_StringMoreThanEightCharacters_ReturnTrue(string input, string shouldBe)
        {
            var result = GeneralUtils.TruncateString(input, 8);
            Assert.AreEqual(shouldBe, result);
        }

        [Test]
        public void AddUntilHundred_SumLessThanHundered_ReturnTrue()
        {
            var result = GeneralUtils.AddUntilHundred(20, 20);
            Assert.AreEqual(40, result);
        }

        [Test]
        public void AddUntilHundred_SumMoreThanHundered_ReturnTrue()
        {
            var result = GeneralUtils.AddUntilHundred(100, 20);
            Assert.AreEqual(100, result);
        }

        [Test]
        public void AddUntilHundred_InputLessThanZero_ReturnTrue()
        {
            var result = GeneralUtils.AddUntilHundred(80, -20);
            Assert.AreEqual(80, result);
        }

        [Test]
        public void Subtract_InputLessThanZero_ReturnTrue()
        {
            var result = GeneralUtils.Subtract(80, -20);
            Assert.AreEqual(60, result);
        }

        [Test]
        public void Subtract_InputMoreThanZero_ReturnTrue()
        {
            var result = GeneralUtils.Subtract(80, 20);
            Assert.AreEqual(60, result);
        }
    }
}
