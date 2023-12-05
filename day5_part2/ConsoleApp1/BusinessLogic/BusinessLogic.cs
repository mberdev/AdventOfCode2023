using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Conversion = ConsoleApp1.InputParse.Conversion;
using Range = ConsoleApp1.InputParse.Range;

namespace ConsoleApp1.BusinessLogic
{
    public static class BusinessLogic
    {
        public static long FindMinimum(Almanach almanach, Range valuesRange, Section sourceSection)
        {
            var isRecursionEnd = SectionsUtil.IsLastSection(sourceSection);
            if (isRecursionEnd)
            {
                // the firt item is always the smallest item
                return valuesRange.Start;
            }

            var conversionsMap = almanach.Maps[(int)sourceSection];
            var conversions = conversionsMap.Conversions.Values;

            var valuesStart = valuesRange.Start;


            var minimum = long.MaxValue;

            var ranges = new List<(Range range, Conversion? conversion)>();

            while (valuesStart <= valuesRange.End)
            {
                var localRange = Range.FromStartEnd(valuesStart, valuesRange.End);

                var containingConversion = conversions
                    .FirstOrDefault(c => c.Start < localRange.Start && c.End > localRange.End);

                // the values to convert are entirely inside a conversion
                if (containingConversion != null)
                {
                    ranges.Add((localRange, containingConversion));

                    // Consume
                    valuesStart = localRange.End + 1;
                    continue;
                }


                var firstIntersectingConversion_StartIntersects = conversions
                    .FirstOrDefault(c => c.Start >= localRange.Start && c.Start <= localRange.End);
                var firstIntersectingConversion_EndIntersects = conversions
                    .FirstOrDefault(c => c.End >= localRange.Start && c.End <= localRange.End);

                // the values to convert are entirely outside of any conversion
                if (firstIntersectingConversion_StartIntersects == null
                        && firstIntersectingConversion_EndIntersects == null)
                {
                    ranges.Add((localRange, null));

                    // Consume
                    valuesStart = localRange.End + 1;
                    continue;
                }

                if (firstIntersectingConversion_EndIntersects != null)
                {
                    var overlappingRange = Range.FromStartEnd(valuesStart, firstIntersectingConversion_EndIntersects.End);

                    ranges.Add((overlappingRange, firstIntersectingConversion_EndIntersects));

                    // Consume
                    valuesStart = firstIntersectingConversion_EndIntersects.End + 1;
                    continue;
                }

                if (firstIntersectingConversion_StartIntersects != null)
                {
                    // there is some no-conversion data before the conversion
                    if (firstIntersectingConversion_StartIntersects.Start > valuesStart)
                    {
                        var noConversionRange = Range.FromStartEnd(valuesStart, firstIntersectingConversion_StartIntersects.Start - 1);

                        ranges.Add((noConversionRange, null));

                        // Consume
                        valuesStart = firstIntersectingConversion_StartIntersects.Start;
                        continue;
                    }
                    // The conversion starts immedately
                    else
                    {
                        var overlappingRange = Range.FromStartEnd(valuesStart, localRange.End);

                        ranges.Add((overlappingRange, firstIntersectingConversion_StartIntersects));

                        // Consume
                        valuesStart = overlappingRange.End + 1;
                        continue;
                    }

                }
            }

            foreach (var (range, conversion) in ranges)
            {

                var convertedRange = conversion != null
                    ? new Range(range.Start + conversion.Offset, range.Length)
                    : range;


                var min = FindMinimum(almanach, convertedRange, conversionsMap.Destination);
                if (min < minimum)
                {
                    minimum = min;
                }

            }

            return minimum;

        }
    }
}
