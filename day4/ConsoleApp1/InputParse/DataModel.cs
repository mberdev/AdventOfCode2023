
namespace ConsoleApp1.InputParse
{
    public class Card
    {
        public int CardNumber { get; }
        public List<int> WinningNumbers { get; }
        public List<int> MyNumbers { get; }

        public Card(int cardNumber, List<int> winningNumbers, List<int> myNumbers)
        {
            CardNumber = cardNumber;
            WinningNumbers = winningNumbers;
            MyNumbers = myNumbers;
        }

        public Card Copy()
        {
            return new Card(CardNumber, WinningNumbers, MyNumbers);
        }

    }
}
