
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);

static void Part1(string[] lines)
{
    var cards = lines.Select(LineDataParser.ParseCard).ToList();

    //foreach (var card in cards)
    //{
    //    Console.WriteLine($"Card {card.CardNumber}");
    //    Console.WriteLine($"Winning Numbers: {string.Join(", ", card.WinningNumbers)}");
    //    Console.WriteLine($"My Numbers: {string.Join(", ", card.MyNumbers)}");
    //    Console.WriteLine($"");
    //}

    var totalPoints = cards.Sum(c =>
    {
        var wins = BusinessLogic.FindWins(c.MyNumbers, c.WinningNumbers);
        var points = BusinessLogic.CountPoints(wins);
        return points;
    });

    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(totalPoints);
    Console.WriteLine($"");
    Console.WriteLine($"");
}

Part1(lines);
//Part2(lines);