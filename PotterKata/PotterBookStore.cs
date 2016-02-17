using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class PotterBookStore
    {
        private const int CostOfASingleBook = 8;
        private const double DiscountToApplyForTwoDifferentBooks = 0.95;
        private const double DiscountToApplyForThreeDifferentBooks = 0.9;

        private double _totalCost;

        private readonly List<string> _booksInTheBasket = new List<string>();
        
        public double Checkout()
        {
            if (DiscountShouldBeApplied())
            {
                return CalculateDiscountedPrice();
            }

            return _totalCost;
        }

        private double CalculateDiscountedPrice()
        {
            if (_booksInTheBasket.Count == 3)
            {
                return _totalCost*DiscountToApplyForThreeDifferentBooks;
            }

            return _totalCost * DiscountToApplyForTwoDifferentBooks;
        }

        private bool DiscountShouldBeApplied()
        {
            return _booksInTheBasket.Count >= 2 && BooksInTheBasketAreNotTheSame();
        }

        private bool BooksInTheBasketAreNotTheSame()
        {
            return _booksInTheBasket.Count == _booksInTheBasket.Distinct().Count();
        }

        public void AddBookToTheBasket(string bookTitle)
        {
            _booksInTheBasket.Add(bookTitle);
            _totalCost += CostOfASingleBook;
        }
    }
}