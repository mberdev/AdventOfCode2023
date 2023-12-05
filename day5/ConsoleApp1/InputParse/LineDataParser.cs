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
            almanach.Seeds.AddRange(ParseSeedsList(seedsGroup.First()));

            var otherGroups = linesGroups.Skip(1).ToList();
            foreach (var group in otherGroups)
            {
                var header = group.First();

                var (sourceName, destinationName) = ParseMapHeader(header);
                var map = new Map(sourceName, destinationName);
                almanach.Maps.Add(map.Key, map);

                var otherLines = group.Skip(1).ToList();
                foreach (var line in otherLines)
                {
                    map.Ranges.Add(ParseRange(line));
                }
            }

            return almanach;
        }

        private static IEnumerable<long> ParseSeedsList(string line)
        {
            var parts = line.Split(' ');
            return parts.Skip(1).Select(long.Parse);
        }

        // "light-to-temperature map:" -> [ "light", "temperature"]
        private static (string sourceName, string destinationName) ParseMapHeader(string line)
        {
            var parts = line.Trim().Split(' ');
            var sections = parts[0].Split('-');
            return (sections[0], sections[2]);
        }

        // "45 77 23" -> { Start: 77, End: 45, Length: 23}
        private static Range ParseRange(string line)
        {
            var values = line.Split(' ').Select(long.Parse).ToArray();
            return new Range(values[0], values[1], values[2]);
        }



    }
}
