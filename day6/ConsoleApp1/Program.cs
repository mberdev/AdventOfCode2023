
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

// Binary search that splits the space in two each time.
// searches on the left side of the space in priority
static int? FindMinimalWinningValue(int minValue, int maxValue, Race race, long recordDistance)
{
    // End of recursion
    if (minValue == maxValue || minValue + 1 == maxValue)
    {
        var minValueWins = BusinessLogic.IsRecordBeaten(BusinessLogic.DoRace(race, minValue), recordDistance);
        var maxValueWins = BusinessLogic.IsRecordBeaten(BusinessLogic.DoRace(race, maxValue), recordDistance);

        if (!minValueWins && !maxValueWins)
            return null;

        if (minValueWins)
            return minValue;
        return maxValue;
    }


    int tryHoldTime = (minValue + maxValue) / 2;

    var myDistance = BusinessLogic.DoRace(race, tryHoldTime);
    if (BusinessLogic.IsRecordBeaten(myDistance, recordDistance))
    {
        // Search left
        return FindMinimalWinningValue(minValue, tryHoldTime, race, recordDistance);

    } else
    {
        // Search right
        return FindMinimalWinningValue(tryHoldTime, maxValue, race, recordDistance);
    }
}


static int? FindMaximalWinningValue(int minValue, int maxValue, Race race, long recordDistance)
{
    // End of recursion
    if (minValue == maxValue || minValue + 1 == maxValue)
    {
        var minValueWins = BusinessLogic.IsRecordBeaten(BusinessLogic.DoRace(race, minValue), recordDistance);
        var maxValueWins = BusinessLogic.IsRecordBeaten(BusinessLogic.DoRace(race, maxValue), recordDistance);

        if (!minValueWins && !maxValueWins)
            return null;

        if (maxValueWins)
            return maxValue;
        return minValue;
    }


    int tryHoldTime = (minValue + maxValue) / 2;

    var myDistance = BusinessLogic.DoRace(race, tryHoldTime);
    if (BusinessLogic.IsRecordBeaten(myDistance, recordDistance))
    {
        // Search right
        return FindMaximalWinningValue(tryHoldTime, maxValue, race, recordDistance);

    }
    else
    {
        // Search left
        return FindMaximalWinningValue(minValue, tryHoldTime, race, recordDistance);
    }
}


static void Part2(string[] lines)
{
    var times = lines[0];
    var distances = lines[1];

    var record = DataParser.Parse_Part2(times, distances);
    Console.WriteLine(record);

    var race = new Race(record.Time);

    // Find minimal holding time
    int? minimalHoldingTime = FindMinimalWinningValue(1, race.TimeLimit - 1, race, record.Distance);


    // Find maximal holding time
    int? maximalHoldingTime = FindMaximalWinningValue(1, race.TimeLimit - 1, race, record.Distance);


    if (minimalHoldingTime == null || maximalHoldingTime == null)
        throw new Exception("No holding time found");

    var successCount = maximalHoldingTime - minimalHoldingTime + 1;


    Console.WriteLine($"=============================");

    Console.WriteLine($"");
    Console.WriteLine($"");
    Console.WriteLine(successCount);
    Console.WriteLine($"");
    Console.WriteLine($"");
}

//-------------------------------------------------------------

var lines = LineBreakParser.ParseInput(Input.File, leaveEmptyLines: false);
//var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: false);

//Part1(lines);
Part2(lines);