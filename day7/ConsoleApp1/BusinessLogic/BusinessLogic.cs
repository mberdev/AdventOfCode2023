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
        public static Dictionary<CardValue, List<CardValue>> GroupCardsDescending(List<CardValue> cardValues)
        {
            return cardValues
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public static HandType FindHandType(int biggestGroupCount, int secondBiggestGroupCount)
        {
            switch (biggestGroupCount)
            {
                case 5:
                    return HandType.FiveOfAKind;
                case 4:
                    return HandType.FourOfAKind;
                case 3:
                    if (secondBiggestGroupCount == 2)
                    {
                        return HandType.FullHouse;
                    }
                    else
                    {
                        return HandType.ThreeOfAKind;
                    }
                case 2:
                    if (secondBiggestGroupCount == 2)
                    {
                        return HandType.TwoPair;
                    }
                    else
                    {
                        return HandType.OnePair;
                    }
                case 1:
                    return HandType.HighCard;
                default:
                    throw new ArgumentException("Invalid number of cards");
            }
        }


        public static Hand AnalyzeHand(List<CardValue> cardValues)
        {
            var groups = GroupCardsDescending(cardValues);

            var biggestGroup = groups.First().Value;
            var secondBiggestGroup = groups.Count > 1
                ? groups.Skip(1).First().Value
                : null;

            HandType handType = FindHandType(biggestGroup.Count, secondBiggestGroup?.Count ?? 0);
     
            return new Hand(
                handType, 
                biggestGroup.First(), 
                secondBiggestGroup?.First() ?? 0
            );
        }


        public static List<Round> SortByStrength(List<Round> rounds)
        {
            var sortedRounds = rounds
                .Select(r => (Round: r, Hand: AnalyzeHand(r.CardValues)))
                .OrderBy(x => x.Hand.Type)
                //.ThenBy(x => x.Hand.Group1Value)
                .ThenBy(x => x.Round.CardValues[0])
                .ThenBy(x => x.Round.CardValues[1])
                .ThenBy(x => x.Round.CardValues[2])
                .ThenBy(x => x.Round.CardValues[3])
                .ThenBy(x => x.Round.CardValues[4])
                //.ThenBy(x => x.Hand.Group2Value)
                .Select(x => x.Round)
                .ToList();

            return sortedRounds;
        }

        public static int CalculateWins(List<Round> sortedRounds)
        { 
            return sortedRounds
                .Select((r, index) =>
                {
                    var rank = index + 1;

                    Console.WriteLine($"{rank} : {string.Join(",", r.CardValues)}  -> {r.Bid * rank}");
                    return r.Bid * rank;
                })
                .Sum();
        }
    }
}
