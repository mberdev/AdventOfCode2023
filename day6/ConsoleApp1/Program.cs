
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System.Linq;



static void Part1(string[] lines)
{
    var times = lines[0];
    var distances = lines[1];

    var pairs = DataParser.Parse(times, distances);
    Printer.Print(pairs);


    //Console.WriteLine($"=============================");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Console.WriteLine(totalPoints);
    //Console.WriteLine($"");
    //Console.WriteLine($"");
}
 

//-------------------------------------------------------------

//var lines = LineBreakParser.ParseInput(Input.File, leaveEmptyLines: false);
var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: false);

Part1(lines);
//Part2(lines);