using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Range = ConsoleApp1.InputParse.Range;

namespace ConsoleApp1.BusinessLogic
{
    public static class BusinessLogic
    {
        public static long ConvertValue(long valueToConvert, Map map)
        {
            var found = TryFindRange(valueToConvert, map, out var range);

            // No explicit range. The destination is the seed
            if (!found)
            {
                return valueToConvert;
            }

            // Explicit range. The destination is defined by the range
            var offset = valueToConvert - range.SourceStart;
            return range.DestinationStart + offset;
        }

        private static bool TryFindRange(long seed, Map map, out Range? range)
        {
            range = map.Ranges.FirstOrDefault(r => IsInRange(seed, r));

            return (range != null);

        }

        private static bool IsInRange(long seed, Range r)
        {
            return r.SourceStart <= seed && seed < r.SourceStart + r.RangeLength;
        }
    }
}
