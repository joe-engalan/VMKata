using NUnit.Framework;

namespace VMKata
{
    [TestFixture]
    class VendingMachineTests
    {
        VendingMachine vm;

        [SetUp]
        public void Init()
        {
            vm = new VendingMachine();
        }

        [Test]
        public void AcceptCoins_QuartersAreAcceptedIntoCoinSlot_CoinSlotContainsQuarters()
        {
            vm.Insert(Coin.Quarter, 3);
            Assert.AreEqual(3, vm.CoinSlot.Count(Coin.Quarter));
        }

        [Test]
        public void AcceptCoins_DimesAreAcceptedInCoinSlot_CoinSlotContainsDimes()
        {
            vm.Insert(Coin.Dime, 1);
            Assert.AreEqual(1, vm.CoinSlot.Count(Coin.Dime));
        }

        [Test]
        public void AcceptCoins_NickelsAreAcceptedInCoinSlot_CoinSlotContainsNickels()
        {
            vm.Insert(Coin.Nickel, 10);
            Assert.AreEqual(10, vm.CoinSlot.Count(Coin.Nickel));
        }

        [Test]
        public void AcceptCoins_PenniesAreRejectedInCoinSlot_CoinReturnContainsPennies()
        {
            vm.Insert(Coin.Penny, 1);
            Assert.AreEqual(1, vm.CoinReturn.Count(Coin.Penny));
        }

        [Test]
        public void AcceptCoins_DisplayMessageWhenCoinSlotIsEmpty_INSERTCOINSIsDisplayed()
        {
            vm.AddToBank(Coin.Quarter, 1);
            Assert.AreEqual("INSERT COINS", vm.Display);
        }

        [Test]
        public void AcceptCoins_DisplayValueWhenCoinSlotIsNotEmpty_Display25CentsWhenQuarterIsInserted()
        {
            vm.Insert(Coin.Quarter, 1);
            Assert.AreEqual("$0.25", vm.Display);
        }

        [Test]
        public void Product_DispenseInStockItem_ItemCountIsDecreasedWhenDispensed()
        {
            vm.Insert(Product.Cola, 2);
            vm.Insert(Coin.Quarter, 4);
            vm.Dispense(Product.Cola);
            Assert.AreEqual(1, vm.Inventory.Count(Product.Cola));
        }

        [Test]
        public void Product_DoNotDispenseIfThereIsntEnoughMoney_ItemCountDoesntDecreaseIfNotEnoughMoney()
        {
            vm.Insert(Product.Candy, 1);
            vm.Dispense(Product.Candy);
            Assert.AreEqual(1, vm.Inventory.Count(Product.Candy));
        }

        [Test]
        public void Product_DisplayTHANKYOUAfterDispensingItem_DisplayWillReadTHANKYOU()
        {
            vm.Insert(Product.Chips, 1);
            vm.Insert(Coin.Quarter, 5);
            vm.Dispense(Product.Chips);
            string display = vm.Display;
            Assert.AreEqual("THANK YOU", display);
        }

        [Test]
        public void Product_DisplayReturnsToPreviousBehaviorAfterThankYouIsSeen_DisplayWillShowInsertCoinsAfterThankYou()
        {
            vm.Insert(Product.Chips, 1);
            vm.Insert(Coin.Quarter, 2);
            vm.Dispense(Product.Chips);
            string display = vm.Display;
            display = vm.Display;
            Assert.AreEqual("INSERT COINS", display);
        }

        [Test]
        public void Product_DisplayPriceIfDispensedWhenThereIsntEnoughMoney_DisplayWillShowPrice()
        {
            vm.Insert(Product.Cola, 1);
            vm.Dispense(Product.Cola);
            string display = vm.Display;
            Assert.AreEqual("PRICE $1.00", display);
        }

        [Test]
        public void Product_DisplayReturnsToPreviousBehaviorAfterPriceIsDisplayed_DisplayWillShowAmountInCoinSlotAfterPrice()
        {
            vm.Insert(Product.Cola, 1);
            vm.Insert(Coin.Quarter, 2);
            vm.Dispense(Product.Cola);
            string display = vm.Display;
            display = vm.Display;
            Assert.AreEqual("$0.50", display);
        }

        [Test]
        public void MakeChange_BalanceDueAfterPurchase_DimeIsPlacedInCoinReturn()
        {
            vm.AddToBank(Coin.Dime, 1);
            vm.Insert(Product.Candy, 1);
            vm.Insert(Coin.Quarter, 3);
            vm.Dispense(Product.Candy);

            Assert.AreEqual(1, vm.CoinReturn.Count(Coin.Dime));
        }

        [Test]
        public void ReturnCoins_ReturnCoinsIsSelected_ContentsOfCoinSlotEmptyIntoCoinReturn()
        {
            vm.Insert(Coin.Quarter, 4);
            vm.ReturnCoins();
            Assert.AreEqual(4, vm.CoinReturn.Count(Coin.Quarter));
        }

        [Test]
        public void ReturnCoins_CoinSlotEmptied_DisplayShowsInsertCoins()
        {
            vm.AddToBank(Coin.Dime, 1);
            vm.Insert(Coin.Quarter, 4);
            vm.ReturnCoins();
            string display = vm.Display;
            Assert.AreEqual("INSERT COINS", display);
        }

        [Test]
        public void SoldOut_ItemIsNotInStockWhenDispensed_DisplayWillReadSoldOut()
        {
            vm.Dispense(Product.Candy);
            string display = vm.Display;
            Assert.AreEqual("SOLD OUT", display);
        }

        [Test]
        public void SoldOut_DisplayWillReturnToPreviousBehaviorAfterSoldOutIsDisplayed_DisplayWillShowAmountInCoinSlot()
        {
            vm.Insert(Coin.Nickel, 10);
            vm.Dispense(Product.Cola);
            string display = vm.Display; // SOLD OUT
            display = vm.Display;
            Assert.AreEqual("$0.50", display);
        }

        [Test]
        public void ExactChangeOnly_HasNoMoneyToMakeChange_DisplayExactChangeOnly()
        {
            string display = vm.Display;
            Assert.AreEqual("EXACT CHANGE ONLY", display);
        }
    }
}
