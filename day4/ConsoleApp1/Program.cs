
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);

static void Part1(string[] lines)
{
    var cards = lines.Select(LineDataParser.ParseCard).ToList();

    foreach (var card in cards)
    {
        Console.WriteLine($"Card {card.CardNumber}");
        Console.WriteLine($"Winning Numbers: {string.Join(", ", card.WinningNumbers)}");
        Console.WriteLine($"My Numbers: {string.Join(", ", card.MyNumbers)}");
        Console.WriteLine($"");
    }

    //Console.WriteLine($"=============================");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Console.WriteLine(sum);
    //Console.WriteLine($"");
    //Console.WriteLine($"");
}

Part1(lines);
//Part2(lines);