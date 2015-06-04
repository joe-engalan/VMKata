using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VMKata
{
    [TestFixture]
    class CoinCollectionTests
    {
        CoinCollection cc;

        [SetUp]
        public void Init()
        {
            cc = new CoinCollection();
        }

        [Test]
        public void Coin_InsertQuarter_ValueBecomes25()
        {
            cc.Insert(Coin.Quarter, 1);
            Assert.AreEqual(25, cc.Value);
        }

        [Test]
        public void Coin_InsertDime_ValueBecomes10()
        {
            cc.Insert(Coin.Dime, 1);
            Assert.AreEqual(10, cc.Value);
        }

        [Test]
        public void Coin_InsertNickel_ValueBecomes5()
        {
            cc.Insert(Coin.Nickel, 1);
            Assert.AreEqual(5, cc.Value);
        }

        [Test]
        public void Coin_InsertPenny_ValueBecomes1()
        {
            cc.Insert(Coin.Penny, 1);
            Assert.AreEqual(1, cc.Value);
        }
    }
}
