
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);



static void Part1(string[] lines)
{
    //foreach (var line in lines)
    //{
    //    var parsed = LineDataParser.ParseTokens(line);
    //    var numbers = string.Join(";", parsed.numbers.Select(n => $"({n.Index},{n.Value})"));
    //    Console.WriteLine($"{line} ->{string.Join(";", parsed.symbols)} | {numbers})");
    //}
    var sum = 0;

    var symbolsRowAbove = new HashSet<int>();
    var (numbersCurrentRow, symbolsCurrentRow) = LineDataParser.ParseTokens(lines[0]);

    var iLine = 0;
    foreach (var line in lines)
    {
        var (numbersRowBelow, symbolsRowBelow) = iLine+1 < lines.Length ? LineDataParser.ParseTokens(lines[iLine+1]) : (new List<NumberToken>(), new HashSet<int>());

        var adjacentNumbers = numbersCurrentRow.Where(number => BusinessLogic.IsAdjacentToSymbol(number, symbolsCurrentRow, symbolsRowAbove, symbolsRowBelow));
        
        Console.WriteLine($"{string.Join(";", adjacentNumbers.Select(n => n.Value))}");

        sum += adjacentNumbers.Sum(n => n.Value);

        // Shift everythig upwards
        symbolsRowAbove = symbolsCurrentRow;

        numbersCurrentRow = numbersRowBelow;
        symbolsCurrentRow = symbolsRowBelow;

        iLine++;
    }

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

    //var sum = lines
    //    .Select(LineDataParser.ParseGame)
    //    .Sum(BusinessLogic.PowerOfRow);

    //Console.WriteLine($"=============================");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Console.WriteLine(sum);
    //Console.WriteLine($"");
    //Console.WriteLine($"");
}

Part1(lines);
//Part2(lines);