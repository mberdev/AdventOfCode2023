
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

//var lines = LineBreakParser.ParseInput(Input.File);
var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines : true);

static void PrintAlmanach(Almanach almanach)
{
    Console.WriteLine($"=============================");

    Console.WriteLine($"Seeds: {string.Join(", ", almanach.Seeds)}");

    foreach (var map in almanach.Maps)
    {
        Console.WriteLine($"Map: {map.Key}");
        foreach (var range in map.Value.Ranges)
        {
            Console.WriteLine($"  {range.DestinationStart} {range.SourceStart} {range.RangeLength}");
        }
    }
}

static void Part1(string[] lines)
{
    var almanach = DataParser.Parse(lines.ToList());

    PrintAlmanach(almanach);

    //Console.WriteLine($"=============================");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Console.WriteLine(totalPoints);
    //Console.WriteLine($"");
    //Console.WriteLine($"");
}

static void Part2(string[] lines)
{


}

Part1(lines);
//Part2(lines);