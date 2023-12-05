
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);
//var lines = LineBreakParser.ParseInput(Input.TestSet);

static void Part1(string[] lines)
{
    var almanach = DataParser.Parse(lines.ToList());

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