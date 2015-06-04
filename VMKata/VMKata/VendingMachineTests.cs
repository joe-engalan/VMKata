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
            vm.CoinSlot.Insert(Coin.Quarter, 3);
            Assert.AreEqual(3, vm.CoinSlot.Quarters);
        }
    }
}
