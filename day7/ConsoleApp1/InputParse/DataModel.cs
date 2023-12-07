
namespace ConsoleApp1.InputParse
{
    public enum CardValue
    {
        A = 0,
        K = 1,
        Q = 2,
        J = 3,
        T = 4,
        _9 = 5,
        _8 = 6,
        _7 = 7,
        _6 = 8,
        _5 = 9,
        _4 = 10,
        _3 = 11,
        _2 = 12,
    }

    public static class CardValuesParser
    {
        public static CardValue Parse(char c)
        {
            if (Enum.TryParse($"{c}", out CardValue result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid CardValues enum value");
            }
        }
    }


    public enum Hand
    {
        HighCard = 0,
        OnePair = 1,
        TwoPair = 2,
        ThreeOfAKind = 3,
        FullHouse = 4,
        FourOfAKind = 5,
        FiveOfAKind = 6,
    }

    public class Round
    {
        public List<CardValue> CardValues { get; }
        public int Bid { get; }

        public Round(List<CardValue> cardValues, int bid)
        {
            CardValues = cardValues;
            Bid = bid;
        }

        public override string ToString()
        {
            return $"{string.Join(",", CardValues)} - {Bid} - {BusinessLogic.BusinessLogic.FindHand(CardValues)}";
        }
    }
}
