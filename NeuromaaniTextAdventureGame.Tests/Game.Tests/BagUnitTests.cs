using NeuromaaniTextAdventureGame.Game;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.Tests.Game.Tests
{
    [TestFixture]
    public class BagUnitTests
    {
        readonly string _mock = "mock";
        readonly string _anotherMock = "anotherMock";
        readonly string _thirdMock = "thirdMock";
        readonly string _fourthMock = "fourthMock";
        List<string> _listOfItems = new List<string>();

        [TearDown]

        public void EmptyListOfItems()
        {
            _listOfItems.Clear();
        }


        [Test]

        public void Add_AddItem_ReturnTrue()
        {
            Bag _bag = CreateBag();

            _bag.AddItemToBag(_mock);

            Assert.Contains(_mock, _listOfItems);

        }

        [Test]

        public void Add_AddItemThatIsAlreadyInBag_ReturnTrue()
        {
            Bag _bag = CreateBag();
            _bag.AddItemToBag(_mock);
            _bag.AddItemToBag(_mock);

            Assert.Contains(_mock, _listOfItems);
        }

        [Test] 

        public void IsItemInBag_ExistingItem_ReturnTrue()
        {
            Bag _bag = CreateBag();
            _bag.AddItemToBag(_mock);
            var result = _bag.IsItemInBag(_mock);
            Assert.IsTrue(result);
        }

        [Test]

        public void IsItemInBag_NonExistingItem_ReturnFalse()
        {
            Bag _bag = CreateBag();
            _bag.AddItemToBag(_mock);
            var result = _bag.IsItemInBag(_anotherMock);
            Assert.IsFalse(result);
        }

        [Test]

        public void Remove_RemoveItem_ReturnTrue()
        {
            Bag _bag = CreateBag();
            _bag.AddItemToBag(_mock);
            _bag.AddItemToBag(_anotherMock);
            _bag.RemoveItemFromBag(_anotherMock);

            Assert.AreEqual("mock", _bag.GetVisibleBag());
        }

        [Test]

        public void Remove_RemoveItemFromEmptyBag_ReturnTrue()
        {
            Bag _bag = CreateBag();
            _bag.RemoveItemFromBag(_mock);

            Assert.IsEmpty(_listOfItems);
        }

        public void Remove_RemoveNonExistentItem_ReturnTrue()
        {
            Bag _bag = CreateBag();
            _bag.AddItemToBag(_mock);
            _bag.RemoveItemFromBag(_anotherMock);

            Assert.AreEqual("mock", _bag.GetVisibleBag());
        }

        [Test]

        public void GetBag_OneItemInBag_ReturnTrue()
        {
            Bag _bag = CreateBag();
            _bag.AddItemToBag(_mock);

            Assert.AreEqual("mock", _bag.GetVisibleBag());
        }

        [Test]

        public void GetBag_ThreeItemsInBag_ReturnTrue()
        {
            Bag _bag = CreateBag();

            _bag.AddItemToBag(_mock);
            _bag.AddItemToBag(_anotherMock);
            _bag.AddItemToBag(_thirdMock);

            Assert.AreEqual("mock, anotherMock, thirdMock", _bag.GetVisibleBag());
        }

        [Test]

        public void GetTruncatedBag_ThreeItemsInBag_ReturnTrue()
        {
            Bag _bag = CreateBag();

            _bag.AddItemToBag(_mock);
            _bag.AddItemToBag(_anotherMock);
            _bag.AddItemToBag(_thirdMock);
            _bag.AddItemToBag(_fourthMock);

            Assert.AreEqual("mock, anotherMock, thirdMock,...", _bag.GetTruncatedVisibleBag());
        }

        private Bag CreateBag()
        {
            return new Bag(_listOfItems);
        }
    }
}
