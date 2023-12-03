
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

var lines = LineBreakParser.ParseInput(Input.File);

static void Part2(string[] lines)
{

    var map = new TokensMap();
    int row = 0;
    foreach (var line in lines)
    {
        map.Tokens.AddRange(LineDataParser.ParseTokens(row, line));
        row++;
    }

    var sum = 0;

    foreach (var symbol in map.Tokens.Where(t => t.IsSymbol))
    {
        var adjacentNumbers = BusinessLogic.NumbersAdjacentToSymbol(map, symbol);
        if (adjacentNumbers.Count == 2)
        {
            sum += adjacentNumbers[0].AsNumber * adjacentNumbers[1].AsNumber;
        }
    }

    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(sum);
    Console.WriteLine($"");
    Console.WriteLine($"");
}

//Part1(lines);
Part2(lines);