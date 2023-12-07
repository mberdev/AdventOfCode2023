
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System.Linq;



static void Part1(string[] lines)
{
    var rounds = DataParser.Parse(lines);


    //Printer.Print(rounds);

    var sortedRounds = BusinessLogic.SortByStrength_Part2(rounds);

    //Console.WriteLine($"===========SORTED===========");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Printer.Print(sortedRounds);


    var wins = BusinessLogic.CalculateWins(sortedRounds);


    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(wins);
    Console.WriteLine($"");
    Console.WriteLine($"");
}


static void Part2(string[] lines)
{
    var rounds = DataParser.Parse(lines);


    //Printer.Print(rounds);

    var sortedRounds = BusinessLogic.SortByStrength_Part2(rounds);

    //Console.WriteLine($"===========SORTED===========");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Printer.Print(sortedRounds);


    var wins = BusinessLogic.CalculateWins(sortedRounds);


    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(wins);
    Console.WriteLine($"");
    Console.WriteLine($"");
}






//-------------------------------------------------------------

var lines = LineBreakParser.ParseInput(Input.File, keepEmptyLines: false);
//var lines = LineBreakParser.ParseInput(Input.TestSet, keepEmptyLines: false);

//Part1(lines);
Part2(lines);