using NUnit.Framework;

namespace VMKata
{
    [TestFixture]
    class CoinCollectionTests
    {
        VendingMachine vm;

        [SetUp]
        public void Init()
        {
            vm = new VendingMachine();
        }

        [Test]
        public void Coin_InsertQuarter_ValueBecomes25()
        {
            vm.Insert(Coin.Quarter, 1);
            Assert.AreEqual(25, vm.CoinSlot.Value);
        }

        [Test]
        public void Coin_InsertDime_ValueBecomes10()
        {
            vm.Insert(Coin.Dime, 1);
            Assert.AreEqual(10, vm.CoinSlot.Value);
        }

        [Test]
        public void Coin_InsertNickel_ValueBecomes5()
        {
            vm.Insert(Coin.Nickel, 1);
            Assert.AreEqual(5, vm.CoinSlot.Value);
        }

        [Test]
        public void Coin_InsertPenny_ValueBecomes1()
        {
            vm.Insert(Coin.Penny, 1);
            Assert.AreEqual(1, vm.CoinReturn.Value);
        }

        [Test]
        public void Coin_StartsEmpty_ValueIs0()
        {
            Assert.AreEqual(0, vm.CoinSlot.Value);
        }

        [Test]
        public void Coin_AddingCoinsAccumulatesValue_OneOfEachCoinIs40()
        {
            vm.Insert(Coin.Quarter, 1);
            vm.Insert(Coin.Nickel, 1);
            vm.Insert(Coin.Dime, 1);
            vm.Insert(Coin.Penny, 1);
            Assert.AreEqual(40, vm.CoinSlot.Value);
        }

        [Test]
        public void Coin_EmptyingIntoAnotherCollectionAddsCoinsToTheOtherCollection_OtherCollectionHasMoreCoins()
        {
            vm.Insert(Product.Chips, 1);
            vm.Insert(Coin.Quarter, 2);
            vm.Dispense(Product.Chips);
            Assert.AreEqual(2, vm.CoinBank.Count(Coin.Quarter));
        }


    }
}
