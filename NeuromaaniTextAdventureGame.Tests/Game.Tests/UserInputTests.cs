using NeuromaaniTextAdventureGame.Game;
using NeuromaaniTextAdventureGame.Rooms;
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
        public void IsCommandMoveNorth_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandMoveNorth(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("itään ")]
        [TestCase(" Itään")]
        [TestCase("Liiku itään ")]
        [TestCase("mene itään")]
        public void IsCommandMoveEast_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandMoveEast(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("etelään ")]
        [TestCase(" ETelään")]
        [TestCase("Liiku etelään ")]
        [TestCase("mene etelään")]
        public void IsCommandMoveSouth_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandMoveSouth(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("länteen ")]
        [TestCase(" LÄnteen")]
        [TestCase("Liiku länteen ")]
        [TestCase("mene länteen")]
        public void IsCommandMoveWest_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandMoveWest(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("apua")]
        [TestCase("Apua  ")]
        [TestCase(" öö")]
        [TestCase("ÖöÖ ")]
        public void IsCommandAskHelp_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandAskHelp(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("alaviite")]
        [TestCase("Alaviite ")]
        [TestCase("av ")]
        [TestCase("AV ")]
        public void IsCommandAskInformation_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandGetFootnote(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("ota tavara")]
        [TestCase("Ota toinen tavara ")]
        public void IsCommandTakeItem_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandTakeItem(input);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsCommandTakeItem_InCorrectInput_ReturnFalse()
        {
            var result = UserInput.IsCommandTakeItem("ota");
            Assert.AreEqual(false, result);
        }

        [TestCase("sano hei")]
        [TestCase("sano MOI")]
        public void IsCommandSayHello_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandSayHello(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("sano Mitä kuuluu ")]
        [TestCase("sano miten menee")]
        public void IsCommandSayHowAreYou_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandSayHowAreYou(input);
            Assert.AreEqual(true, result);
        }

        [TestCase(" sano Idiootti ")]
        [TestCase("sano hölmö")]
        [TestCase("sano TYHMä ")]
        public void IsCommandSayStupid_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandSayStupid(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("käytä tavara")]
        [TestCase("Käytä tavara ")]
        [TestCase("Käytä  Tavara ")]
        public void IsCommandUseItem_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandUseItem(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("Lyö  ")]
        [TestCase("lyö")]

        public void IsCommandAction_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandHit(input);
            Assert.AreEqual(true, result);
        }

        [TestCase("astu sisään  ")]
        [TestCase("Astu Ovesta")]
        public void IsCommandExitRoom_CorrectInput_ReturnTrue(string input)
        {
            var result = UserInput.IsCommandExitRoom(input);
            Assert.AreEqual(true, result);
        }

        //[TestCase("Lopeta")]
        //[TestCase(" lopeta ")]
        //public void IsCommandExitGame_CorrectInput_ReturnTrue(string input)
        //{
        //    var result = UserInput.IsCommandExitGame(input);
        //    Assert.AreEqual(true, result);
        //}

        [TestCase("mene pohjoiseen", Command.North)]
        [TestCase("mene Itään", Command.East)]
        [TestCase("liiku etelään ", Command.South)]
        [TestCase(" Länteen", Command.West)]
        [TestCase("sano HEI", Command.Hello)]
        [TestCase(" sano idiootti", Command.Stupid)]
        [TestCase("sano miten Menee ", Command.HowAreYou)]
        [TestCase(" käytä tavara", Command.UseItem)]
        [TestCase(" lyö", Command.Hit)]
        [TestCase(" av ", Command.GetFootnote)]
        [TestCase("ööö", Command.AskHelp)]
        [TestCase("ota tavara ", Command.TakeItem)]
        [TestCase("astu ovesta ", Command.ExitRoom)]
        [TestCase(" lopeta ", Command.ExitGame)]
        public void ConvertCommandToEnum_DifferentCommands_ReturnTrue(string command, Command output)
        {
            var result = UserInput.ConvertCommand(command);
            Assert.AreEqual(output, result);
        }

        [Test]

        public void GenerateRandomAnswer_OnePossibleAnswer_ReturnTrue()
        {
            string[] answers = { "Hei" };
            var result = PlayRoom.GenerateRandomAnswer(answers);
            Assert.AreEqual("Hei", result);
        }

    }
}
