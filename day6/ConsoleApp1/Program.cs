
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System.Linq;



static void Part1(string[] lines)
{
    var times = lines[0];
    var distances = lines[1];

    var records = DataParser.Parse_Part1(times, distances);
    Printer.Print(records);

    var total = 1;
    foreach ( var record in records )
    {
        var race = new Race(record.Time);

        int successCount = 0;
        for (int holdTime = 1; holdTime < record.Time;  holdTime++)
        {
            
            var myDistance = BusinessLogic.DoRace(race, holdTime);
            if (BusinessLogic.IsRecordBeaten(myDistance, record.Distance))
            {
                successCount++;
            }
        }

        total *= successCount;

    }

    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(total);
    Console.WriteLine($"");
    Console.WriteLine($"");
}


static void Part2(string[] lines)
{
    var times = lines[0];
    var distances = lines[1];

    var record = DataParser.Parse_Part2(times, distances);
    Console.WriteLine(record);

    //var total = 1;
    //foreach (var record in records)
    //{
    //    var race = new Race(record.Time);

    //    int successCount = 0;
    //    for (int holdTime = 1; holdTime < record.Time; holdTime++)
    //    {

    //        var myDistance = BusinessLogic.DoRace(race, holdTime);
    //        if (BusinessLogic.IsRecordBeaten(myDistance, record.Distance))
    //        {
    //            successCount++;
    //        }
    //    }

    //    total *= successCount;

    //}

    //Console.WriteLine($"=============================");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Console.WriteLine(total);
    //Console.WriteLine($"");
    //Console.WriteLine($"");
}

//-------------------------------------------------------------

//var lines = LineBreakParser.ParseInput(Input.File, leaveEmptyLines: false);
var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: false);

//Part1(lines);
Part2(lines);