﻿using NeuromaaniTextAdventureGame.Game;
using NUnit.Framework;

namespace NeuromaaniTextAdventureGame.Tests.Game.Tests
{
    [TestFixture]
    public class UserInputTests
    {
        [TestCase("pohjoiseen")]
        [TestCase("Pohjoiseen")]
        [TestCase("Pohjoiseen ")]
        [TestCase("mene pohjoiseen")]
        [TestCase("Liiku Länteen")]

        public void isCommandDirection_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandDirection(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("apua")]
        [TestCase("ÖöÖ ")]
        public void isCommandAskHelp_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandAskHelp(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("ota tavara")]
        [TestCase("Ota toinen tavara ")]
        public void isCommandTakeItem_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandTakeItem(input);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void isCommandTakeItem_InCorrectInput_ReturnFalse()
        {
            var result = UserInput.IsCommandTakeItem("ota");
            Assert.AreEqual(false, result);
        }

        [TestCase("sano hei")]
        [TestCase("Sano mitä kuuluu ")]
        [TestCase("Sano Mitä kuuluu ")]
        public void isCommandSay_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandSay(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("Lyö ")]
        [TestCase("lyö")]

        public void isCommandAction_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandAction(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("pohjoiseen", Direction.North)]
        [TestCase("mene itään", Direction.East)]
        [TestCase("länteen", Direction.West)]
        [TestCase("mene etelään", Direction.South)]
        [TestCase("mitä tahansa muuta", Direction.Default)]
        public void convertCommandToDirectionEnum_CorrectInput_ReturnCorrectDirection(string input, Direction output)
        {
            var result = UserInput.ConvertCommandToDirectionEnum(input);
            Assert.AreEqual(output, result);
        }

        [TestCase("sano hei", Say.Hello)]
        [TestCase("sano Moi", Say.Hello)]
        [TestCase("mene mitä kuuluu", Say.HowAreYou)]
        [TestCase("mene miten Menee ", Say.HowAreYou)]
        [TestCase("sano idiootti", Say.Stupid)]
        [TestCase("Sano hölMö", Say.Stupid)]
        public void ConvertGeneralSayCommandEnum_CorrectInput_ReturnCorrectSay(string input, Say output)
        {
            var result = UserInput.ConvertGeneralSayCommandEnum(input);
            Assert.AreEqual(output, result);
        }

        [Test]
        public void convertActionCommandToEnum_CorrectInput_ReturnTrue()
        {
            var result = UserInput.ConvertActionCommandToEnum("Lyö ");
            Assert.AreEqual(SpecialAction.Hit, result);
        }

        [Test]
        public void convertActionCommandToEnum_IncorrectInput_ReturnFalse() { 
        
            var result = UserInput.ConvertActionCommandToEnum("jokin käsky");
            Assert.AreEqual(SpecialAction.Default, result);
        }

        [Test]

        public void generateRandomAnswer_OnePossibleAnswer_ReturnTrue()
        {
            string[] answers = { "Hei" };
            var result = UserInput.generateRandomAnswer(answers);
            Assert.AreEqual("Hei", result);
        }

    }
}