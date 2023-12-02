
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);

foreach (var line in lines)
{
    var parsed = LineDataParser.ParseLine(line);
    Console.WriteLine($"{line} ->{parsed.GameIndex} : {string.Join(";", parsed.Rounds.Select(r => r.ToString()))}");
}

var sum = lines
    .Select(l => LineDataParser.ParseLine(l))
    .Sum(l => {
        var isPossible = !BusinessLogic.RowBreaksLogic(l);
        return isPossible ? l.GameIndex : 0;
    });

Console.WriteLine($"=============================");

Console.WriteLine($"");
Console.WriteLine($"");
Console.WriteLine(sum);
Console.WriteLine($"");
Console.WriteLine($"");
