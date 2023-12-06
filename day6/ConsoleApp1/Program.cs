
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;



static void Part1(string[] lines)
{
    //var almanach = DataParser.Parse(lines.ToList());


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