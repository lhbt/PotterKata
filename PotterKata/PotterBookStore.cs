using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class PotterBookStore
    {
        private const int CostOfASingleBook = 8;
        private const double DiscountToApplyForTwoDifferentBooks = 0.95;
        private const double DiscountToApplyForThreeDifferentBooks = 0.9;
        private const double DiscountToApplyForFourDifferentBooks = 0.8;

        private double _totalCost;

        private readonly Dictionary<int, double> _discountsToApplyByNumberOfDifferentBooksInTheBasket = new Dictionary<int, double>
        {
            { 2, DiscountToApplyForTwoDifferentBooks },
            { 3, DiscountToApplyForThreeDifferentBooks },
            { 4, DiscountToApplyForFourDifferentBooks },
        }; 

        private readonly List<string> _booksInTheBasket = new List<string>();

        public void AddBookToTheBasket(string bookTitle)
        {
            _booksInTheBasket.Add(bookTitle);
            _totalCost += CostOfASingleBook;
        }

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
            var discountToApply = GetDiscountToApply();
            
            return _totalCost * discountToApply;
        }

        private double GetDiscountToApply()
        {
            var numberOfDifferentBooksInTheBasket = GetNumberOfDifferentBooksInTheBasket();

            return _discountsToApplyByNumberOfDifferentBooksInTheBasket[numberOfDifferentBooksInTheBasket];
        }

        private bool DiscountShouldBeApplied()
        {
            var thereAreAtLeastTwoBooksInTheBasket = _booksInTheBasket.Count >= 2;

            return thereAreAtLeastTwoBooksInTheBasket && BooksInTheBasketAreNotTheSame();
        }

        private bool BooksInTheBasketAreNotTheSame()
        {
            return _booksInTheBasket.Count == GetNumberOfDifferentBooksInTheBasket();
        }
        
        private int GetNumberOfDifferentBooksInTheBasket()
        {
            return _booksInTheBasket.Distinct().Count();
        }
    }
}