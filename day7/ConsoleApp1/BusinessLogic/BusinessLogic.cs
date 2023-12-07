using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.BusinessLogic
{
    public static class BusinessLogic
    {
        public static Dictionary<CardValue, List<CardValue>> GroupCards(List<CardValue> cardValues)
        {
            return cardValues
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public static Hand FindHand(List<CardValue> cardValues)
        {
            var groups = GroupCards(cardValues);

            var biggestGroup = groups.First().Value;
            var secondBiggestGroup = groups.Count > 1
                ? groups.Skip(1).First().Value
                : null;

            switch (biggestGroup.Count)
            {
                case 5:
                    return Hand.FiveOfAKind;
                case 4:
                    return Hand.FourOfAKind;
                case 3:
                    if (secondBiggestGroup!.Count == 2)
                    {
                        return Hand.FullHouse;
                    }
                    else
                    {
                        return Hand.ThreeOfAKind;
                    }
                case 2:
                    if (secondBiggestGroup!.Count == 2)
                    {
                        return Hand.TwoPair;
                    }
                    else
                    {
                        return Hand.OnePair;
                    }
                case 1:
                    return Hand.HighCard;
                default:
                    throw new ArgumentException("Invalid number of cards");
            }

        }
    }
}
