
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);
//var lines = LineBreakParser.ParseInput(Input.TestSet);

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

static void Part2(string[] lines)
{
    var originalCards = lines.Select(LineDataParser.ParseCard).ToDictionary(c => c.CardNumber, c => c);

    var cardsToProcess = new Stack<Card>(originalCards.Values);
    //var cardsPossessed = new Stack<Card>();
    var cardsPossessedCount = 0;

    //foreach (var card in cards)
    //{
    //    Console.WriteLine($"Card {card.CardNumber}");
    //    Console.WriteLine($"Winning Numbers: {string.Join(", ", card.WinningNumbers)}");
    //    Console.WriteLine($"My Numbers: {string.Join(", ", card.MyNumbers)}");
    //    Console.WriteLine($"");
    //}

    int limit = 500000000; // Safety
    int count = 0;
    // Spawn copies from copies
    while(cardsToProcess.Any() && count < limit)
    {
        var card = cardsToProcess.Pop();
        //cardsPossessed.Push(card);
        cardsPossessedCount++;

        //Console.WriteLine($"{card.CardNumber}");

        var copies = BusinessLogic.SpawnCopies(originalCards, card);
        foreach (var copy in copies)
        {
            cardsToProcess.Push(copy);
        }

        //Console.WriteLine($"Total {cardsPossessed.Count}");
        count++;
    }

    if (count == limit)
        throw new Exception("Limit reached");


    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(cardsPossessedCount);
    Console.WriteLine($"");
    Console.WriteLine($"");
}

//Part1(lines);
Part2(lines);