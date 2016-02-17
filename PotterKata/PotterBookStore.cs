using System.Collections.Generic;

namespace PotterKata
{
    public class PotterBookStore
    {
        private const int CostOfASingleBook = 8;
        private double _cost;
        private readonly List<string> _booksInTheBasket = new List<string>();
        
        public double Checkout()
        {
            if (DiscountShouldBeApplied())
                return CalculateDiscountedPrice();
            return _cost;
        }

        private double CalculateDiscountedPrice()
        {
            return _cost * 0.95;
        }

        private bool DiscountShouldBeApplied()
        {
            return _booksInTheBasket.Count == 2 && BooksInTheBasketAreNotTheSame();
        }

        private bool BooksInTheBasketAreNotTheSame()
        {
            return (_booksInTheBasket[0] != _booksInTheBasket[1]);
        }

        public void AddBookToTheBasket(string bookTitle)
        {
            _booksInTheBasket.Add(bookTitle);
            _cost += CostOfASingleBook;
        }
    }
}