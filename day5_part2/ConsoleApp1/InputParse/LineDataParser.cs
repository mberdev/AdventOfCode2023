using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public class DataParser
    {

        public static Almanach Parse(List<string> input)
        {
            var almanach = new Almanach();

            var linesGroups = StringSeparator.Separate(input);

            var seedsGroup = linesGroups[0];
            almanach.SeedRanges.AddRange(ParseSeedsList(seedsGroup.First()));

            var otherGroups = linesGroups.Skip(1).ToList();
            foreach (var group in otherGroups)
            {
                var header = group.First();

                var (source, destination) = ParseMapHeader(header);
                var map = new Map(source, destination);
                almanach.Maps[(int)map.Source] = map;

                var otherLines = group.Skip(1).ToList();
                foreach (var line in otherLines)
                {
                    var conversion = ParseRange(line);
                    map.Conversions.Add(conversion.Start, conversion);
                }
            }

            return almanach;
        }


        private static List<Range> ParseSeedsList(string line)
        {
            var parts = line.Split(' ');
            var values = parts.Skip(1).Select(long.Parse).ToArray();

            if (values.Length % 2 != 0)
            {
                throw new Exception("Should be an even number of values");
            }

            // Classic way of iterating on pairs of values
            return Enumerable.Range(0, values.Length / 2)
                .Select(i => new Range(values[i * 2], values[i*2+1]))
                .ToList();
        }

        // "light-to-temperature map:" -> [ "light", "temperature"]
        private static (Section source, Section destination) ParseMapHeader(string line)
        {
            var parts = line.Trim().Split(' ');
            var sections = parts[0].Split('-');
            return (Enum.Parse<Section>(sections[0]), Enum.Parse<Section>(sections[2]));
        }

        // "45 77 23" -> { Start: 77, End: 45, Length: 23}
        private static Conversion ParseRange(string line)
        {
            var values = line.Split(' ').Select(long.Parse).ToArray();
            var destinationStart = values[0];
            var sourceStart = values[1];
            var length = values[2];

            var sourceRange = new Range(sourceStart, length);
            var offset = destinationStart - sourceStart;
            return new Conversion(sourceRange, offset);
        }



    }
}
