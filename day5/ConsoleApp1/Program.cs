
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

//var lines = LineBreakParser.ParseInput(Input.File, leaveEmptyLines: true);
var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: true);

// Optional. For control.
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

static Map FindNextConversion(Almanach almanach, string source)
{
    return almanach.Maps.Values.First(m => m.SourceName == source);
}

static void Part1(string[] lines)
{
    var almanach = DataParser.Parse(lines.ToList());
    PrintAlmanach(almanach);

    Console.WriteLine($"=============================");


    var source = "seed";
    var conversion = FindNextConversion(almanach, source);
    
    var finalDestination = "location";

    var values = almanach.Seeds.ToList();

    while (conversion.DestinationName != finalDestination)
    {
        var converted = values.Select(v => BusinessLogic.ConvertValue(v, conversion)).ToList();

        //Optional
        PrintConversion(values, conversion, converted);

        source = conversion.DestinationName;
        conversion = FindNextConversion(almanach, source);
        values = converted;
    }

    var convertedFinal = values.Select(v => BusinessLogic.ConvertValue(v, conversion)).ToList();

    //Optional
    PrintConversion(values, conversion, convertedFinal);






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


//Optional. For control.
static void PrintConversion(List<long> values, Map map, List<long> converted)
{
    Console.WriteLine($"Searching {map.SourceName} to {map.DestinationName}");

    // iterate on both values and converted at the same time. For each pair of value, write a string to console
    for (int i = 0; i < values.Count; i++)
    {
        Console.WriteLine($"{values[i]} -> {converted[i]}");
    }

    Console.WriteLine($"=============================");
    Console.WriteLine($"{converted.Min()}");

    Console.WriteLine($"=============================");
}
//Part2(lines);