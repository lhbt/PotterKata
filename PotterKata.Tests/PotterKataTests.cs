using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class PotterKataTests
    {
        private PotterBookStore _potterBookStore;

        [SetUp]
        public void SetUp()
        {
            _potterBookStore = new PotterBookStore();
        }

        [Test]
        public void cost_at_the_checkout_without_any_book_in_the_basket_should_be_zero()
        {
            OnCheckoutCostShouldBe(0);
        }
        
        [Test]
        public void when_we_add_the_first_book_to_the_basket_and_we_checkout_the_cost_is_8()
        {
            AddBookToTheBasket("First book");

            OnCheckoutCostShouldBe(8);
        }

        [Test]
        public void when_we_add_the_first_book_to_the_basket_twice_the_cost_is_16()
        {
            AddBookToTheBasket("First book");
            AddBookToTheBasket("First book");

            OnCheckoutCostShouldBe(16.0);
        }

        [Test]
        public void when_we_add_the_first_book_and_the_second_book_to_the_basket_a_5_percent_discount_applies_so_the_cost_is_15_euros_20_on_checkout()
        {
            AddBookToTheBasket("First book");
            AddBookToTheBasket("Second book");

            OnCheckoutCostShouldBe(15.20);
        }

        private void AddBookToTheBasket(string bookTitle)
        {
            _potterBookStore.AddBookToTheBasket(bookTitle);
        }

        private void OnCheckoutCostShouldBe(double expectedCost)
        {
            var cost = _potterBookStore.Checkout();

            Assert.AreEqual(expectedCost, cost);
        }
    }
}
