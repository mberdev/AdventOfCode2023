using ConsoleApp1.InputParse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Util
{
    public static class Printer
    {
        // Optional. For control.
        public static void PrintAlmanach(Almanach almanach)
        {
            WriteLine($"=============================");

            var ranges = almanach.SeedRanges.Select(r => $"[{r.Start},{r.End}]").ToList();
            WriteLine($"Seed ranges: {string.Join(", ", ranges)}");

            foreach (var map in almanach.Maps)
            {
                if (map == null)
                    continue;

                WriteLine($"Map: {map.Source} -> {map.Destination}");
                foreach (var conversion in map.Conversions)
                {
                    WriteLine($"  {conversion.Value.Start} {conversion.Value.SourceRange.Length}, offset {conversion.Value.Offset}");
                }
            }

            WriteLine($"=============================");
            WriteLine("");
            WriteLine("");
        }


        public static void WriteLine(string message)
        {
            bool verbose = false;
            if (verbose)
                Console.WriteLine(message);
        }
    }


}
