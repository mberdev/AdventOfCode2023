
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

//var lines = LineBreakParser.ParseInput(Input.File, leaveEmptyLines: true);
var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: true);

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
        values = Convert(values, conversion);

        source = conversion.DestinationName;
        conversion = FindNextConversion(almanach, source);
    }

    values = Convert(values, conversion);






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

static List<long> Convert(List<long> values, Map map)
{
    var converted = values.Select(v => BusinessLogic.ConvertValue(v, map)).ToArray();

    Console.WriteLine($"Searching {map.SourceName} to {map.DestinationName}");

    // iterate on both values and converted at the same time. For each pair of value, write a string to console
    for (int i = 0; i < values.Count; i++)
    {
        Console.WriteLine($"{values[i]} -> {converted[i]}");
    }

    Console.WriteLine($"=============================");
    Console.WriteLine($"{converted.Min()}");

    Console.WriteLine($"=============================");

    return converted.ToList();

}
//Part2(lines);