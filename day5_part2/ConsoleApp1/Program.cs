
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System;
using System.Collections.Immutable;
using System.Linq;
using Range = ConsoleApp1.InputParse.Range;




static void Part2(string[] lines)
{
    var almanach = DataParser.Parse(lines.ToList());
    
    //Optional. For control.
    Printer.PrintAlmanach(almanach);

    var minimum = long.MaxValue;
    foreach (var range in almanach.SeedRanges)
    {
        var min = BusinessLogic.FindMinimum(almanach, range, Section.seed);
        if (min < minimum)
        {
            minimum = min;
        }
    }

    Console.WriteLine($"Minimum: {minimum}");
}









//------------------- MAIN -------------------------------------

var lines = LineBreakParser.ParseInput(Input.File, leaveEmptyLines: true);
//var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: true);

//Part1(lines);
Part2(lines);