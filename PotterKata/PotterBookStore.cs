namespace PotterKata
{
    public class PotterBookStore
    {
        private double _cost;

        public double Checkout()
        {
            return _cost;
        }

        public void AddBookToTheBasket(string firstBook)
        {
            _cost = 8;
        }
    }
}