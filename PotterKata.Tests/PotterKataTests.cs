using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class PotterKataTests
    {
        [Test]
        public void cost_at_the_checkout_without_any_book_in_the_basket_should_be_zero()
        {
            var potterBookStore = new PotterBookStore();

            var cost = potterBookStore.Checkout();

            Assert.AreEqual(0, cost);
        }
    }
}
