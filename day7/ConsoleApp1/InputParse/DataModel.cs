
namespace ConsoleApp1.InputParse
{
    //Part 1
    //public enum CardValue
    //{
    //    _2 = 2,
    //    _3 = 3,
    //    _4 = 4,
    //    _5 = 5,
    //    _6 = 6,
    //    _7 = 7,
    //    _8 = 8,
    //    _9 = 9,
    //    T = 10,
    //    J = 11,
    //    Q = 12,
    //    K = 13,
    //    A = 14,
    //}

    //Part 2
    public enum CardValue
    {
        J = 1,

        _2 = 2,
        _3 = 3,
        _4 = 4,
        _5 = 5,
        _6 = 6,
        _7 = 7,
        _8 = 8,
        _9 = 9,
        T = 10,

        Q = 12,
        K = 13,
        A = 14,
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


    public enum HandType
    {
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        FullHouse = 5,
        FourOfAKind = 6,
        FiveOfAKind = 7,
    }

    public class Hand
    {
        public HandType Type { get; }
        public CardValue Group1Value { get; }
        public CardValue Group2Value { get; }

        public Hand(HandType type, CardValue group1Value, CardValue group2Value)
        {
            Type = type;
            Group1Value = group1Value;
            Group2Value = group2Value;
        }
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
            return $"{string.Join(",", CardValues)} - {Bid} - {BusinessLogic.BusinessLogic.AnalyzeHand_Regular(CardValues).Type}";
        }
    }
}
