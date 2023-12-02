
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);



static void Part1(string[] lines)
{
    //foreach (var line in lines)
    //{
    //    var parsed = LineDataParser.ParseLine(line);
    //    Console.WriteLine($"{line} ->{parsed.GameIndex} : {string.Join(";", parsed.Rounds.Select(r => r.ToString()))}");
    //}

    var sum = lines
        .Select(line => LineDataParser.ParseGame(line))
        .Sum(game =>
        {
            var isPossible = !BusinessLogic.GameBreaksLimits(game);
            return isPossible ? game.GameIndex : 0;
        });

    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(sum);
    Console.WriteLine($"");
    Console.WriteLine($"");
}

static void Part2(string[] lines)
{
    //foreach (var line in lines)
    //{
    //    var parsed = LineDataParser.ParseLine(line);
    //    Console.WriteLine($"{line} ->{parsed.GameIndex} : {string.Join(";", parsed.Rounds.Select(r => r.ToString()))}");
    //}

    var sum = lines
        .Select(line => LineDataParser.ParseGame(line))
        .Sum(game => BusinessLogic.PowerOfRow(game));

    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(sum);
    Console.WriteLine($"");
    Console.WriteLine($"");
}

//Part1(lines);
Part2(lines);