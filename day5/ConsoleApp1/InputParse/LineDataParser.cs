using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public static class LineDataParser
    {
        //                                         g1          g2       g3           g4       g5
        private static string pattern = @"^Card\s*(\d+)\s*:\s*(\d+\s+)*(\d+\s*)\|\s*(\d+\s+)*(\d+)$";

        private static Regex regex = new Regex(pattern, RegexOptions.Compiled);

        public static Card ParseCard(string input)
        {
            var parsed = regex.Matches(input).First();
            var rowNumber = int.Parse(parsed.Groups[1].Captures.First().Value);

            // there are always 10 "winning Numbers numbers" 
            var winningNumbers = parsed.Groups[2].Captures.Select(c => int.Parse(c.Value)).ToList();
            winningNumbers.AddRange(parsed.Groups[3].Captures.Select(c => int.Parse(c.Value)));

            // the rest is always "my numbers"
            var myNumbers = parsed.Groups[4].Captures.Select(c => int.Parse(c.Value)).ToList();
            myNumbers.AddRange(parsed.Groups[5].Captures.Select(c => int.Parse(c.Value)));

            return new Card(
                rowNumber, 
                winningNumbers.ToList(), 
                myNumbers.ToList()
            );
        }
        
    }
}
