
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System.Linq;



static void Part1(string[] lines)
{
    var rounds = DataParser.Parse(lines);
    Printer.Print(rounds);



    //Console.WriteLine($"=============================");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Console.WriteLine(total);
    //Console.WriteLine($"");
    //Console.WriteLine($"");
}






//-------------------------------------------------------------

var lines = LineBreakParser.ParseInput(Input.File, keepEmptyLines: false);
//var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: false);

Part1(lines);
//Part2(lines);