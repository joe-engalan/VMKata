using NUnit.Framework;

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

        [Test]
        public void Product_ValidateCandyCost_CandyCosts65()
        {
            Assert.AreEqual(65, vm.GetPrice(Product.Candy));
        }
    }
}
