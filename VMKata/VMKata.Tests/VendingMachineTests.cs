using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.AreEqual(3, vm.CoinSlot.Quarters);
        }

        [Test]
        public void AcceptCoins_DimesAreAcceptedInCoinSlot_CoinSlotContainsDimes()
        {
            vm.Insert(Coin.Dime, 1);
            Assert.AreEqual(1, vm.CoinSlot.Dimes);
        }

        [Test]
        public void AcceptCoins_NickelsAreAcceptedInCoinSlot_CoinSlotContainsNickels()
        {
            vm.Insert(Coin.Nickel, 10);
            Assert.AreEqual(10, vm.CoinSlot.Nickels);
        }

        [Test]
        public void AcceptCoins_PenniesAreRejectedInCoinSlot_CoinReturnContainsPennies()
        {
            vm.Insert(Coin.Penny, 1);
            Assert.AreEqual(1, vm.CoinReturn.Pennies);
        }

        [Test]
        public void AcceptCoins_DisplayMessageWhenCoinSlotIsEmpty_INSERTCOINSIsDisplayed()
        {
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
            Assert.AreEqual(1, vm.Inventory.Colas);
        }

        [Test]
        public void Product_DoNotDispenseIfThereIsntEnoughMoney_ItemCountDoesntDecreaseIfNotEnoughMoney()
        {
            vm.Insert(Product.Candy, 1);
            vm.Dispense(Product.Candy);
            Assert.AreEqual(1, vm.Inventory.Candies);
        }
    }
}
