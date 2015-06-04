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
        [Test]
        public void Coin_InsertQuarterToCoinCollection_ValueBecomes25()
        {
            CoinCollection cc = new CoinCollection();
            cc.Insert(Coin.Quarter, 1);
            Assert.AreEqual(25, cc.Value);
        }
    }
}
