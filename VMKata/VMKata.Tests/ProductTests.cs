using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VMKata;

namespace VMKata.Tests
{
    [TestFixture]
    class ProductTests
    {
        VendingMachine vm;
        [SetUp]
        public void Init()
        {
            vm = new VendingMachine();
        }

        [Test]
        public void Product_ValidateColaCost_ColaCosts100()
        {
            Assert.AreEqual(100, vm.GetPrice(Product.Cola));  
        }

        [Test]
        public void Product_ValidChipsCost_ChipsCost50()
        {
            Assert.AreEqual(50, vm.GetPrice(Product.Chips));
        }
    }
}
