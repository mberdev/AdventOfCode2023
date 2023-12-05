
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;



// Optional. For control.
static void PrintAlmanach_Part1(Almanach_Part1 almanach)
{
    Console.WriteLine($"=============================");

    Console.WriteLine($"Seeds: {string.Join(", ", almanach.Seeds)}");

    foreach (var map in almanach.Maps)
    {
        if (map == null)
            continue;

        Console.WriteLine($"Map: {map.Source} -> { map.Destination }");
        foreach (var range in map.Ranges)
        {
            Console.WriteLine($"  {range.DestinationStart} {range.SourceStart} {range.RangeLength}");
        }
    }
}

// Optional. For control.
static void PrintAlmanach_Part2(Almanach_Part2 almanach)
{
    Console.WriteLine($"=============================");

    var ranges = almanach.SeedRanges.Select(r => $"[{r.Start},{r.End}]").ToList();
    Console.WriteLine($"Seed ranges: {string.Join(", ", ranges)}");

    foreach (var map in almanach.Maps)
    {
        if (map == null)
            continue;

        Console.WriteLine($"Map: {map.Source} -> {map.Destination}");
        foreach (var range in map.Ranges)
        {
            Console.WriteLine($"  {range.DestinationStart} {range.SourceStart} {range.RangeLength}");
        }
    }
}

static Map FindNextConversion(IConversionsStore almanach, Sections source)
{
    return almanach.Maps[(int)source];
}

//Optional. For control.
static void PrintConversion(List<long> values, Map map, List<long> converted)
{
    Console.WriteLine($"Searching {map.Source} to {map.Destination}");

    // iterate on both values and converted at the same time. For each pair of value, write a string to console
    for (int i = 0; i < values.Count; i++)
    {
        Console.WriteLine($"{values[i]} -> {converted[i]}");
    }

    Console.WriteLine($"=============================");
    Console.WriteLine($"{converted.Min()}");

    Console.WriteLine($"=============================");
}



static void Part1(string[] lines)
{
    var almanach = DataParser.Parse_Part1(lines.ToList());
    PrintAlmanach_Part1(almanach);

    Console.WriteLine($"=============================");


    var source = Sections.seed;
    var conversion = FindNextConversion(almanach, source);
    
    var finalDestination = Sections.location;

    var values = almanach.Seeds.ToList();

    while (conversion.Destination != finalDestination)
    {
        var converted = values.Select(v => BusinessLogic.ConvertValue(v, conversion)).ToList();

        //Optional
        PrintConversion(values, conversion, converted);

        source = conversion.Destination;
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
    
// This brute-force method works only on the small sample set
static void Part2_BruteForce(string[] lines)
{
    var almanach = DataParser.Parse_Part2(lines.ToList());
    PrintAlmanach_Part2(almanach);


    long min = long.MaxValue;

    foreach (var range in almanach.SeedRanges)
    {
        var seed = range.Start;

        while (seed <= range.End)
        {
            var source = Sections.seed;
            var conversion = FindNextConversion(almanach, source);

            var finalDestination = Sections.location;

            var value = seed;
            while (conversion.Destination != finalDestination)
            {
                var converted = BusinessLogic.ConvertValue(value, conversion);

                source = conversion.Destination;
                conversion = FindNextConversion(almanach, source);
                value = converted;
            }

            var convertedFinal = BusinessLogic.ConvertValue(value, conversion);

            if (convertedFinal < min)
                min = convertedFinal;

            seed++;
        }


    }

    Console.WriteLine($"min {min}");



    //Console.WriteLine($"=============================");

    //Console.WriteLine($"");
    //Console.WriteLine($"");
    //Console.WriteLine(totalPoints);
    //Console.WriteLine($"");
    //Console.WriteLine($"");

}


//-------------------------------------------------------------

//var lines = LineBreakParser.ParseInput(Input.File, leaveEmptyLines: true);
var lines = LineBreakParser.ParseInput(Input.TestSet, leaveEmptyLines: true);

//Part1(lines);
Part2_BruteForce(lines);