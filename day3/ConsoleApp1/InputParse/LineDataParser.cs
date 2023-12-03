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
        public static List<Token> ParseTokens(int row, string input)
        {
            // Note: The two regex below could have been combined.

            // Parsing integers
            var numbers = Regex.Matches(input, @"\d+");
            var tokens = numbers.Select(m => new Token(row, m.Index, m.Value)).ToList();

            // Parsing one-character symbols
            var symbols = Regex.Matches(input, @"[^.\s\d]");
            tokens.AddRange(
                symbols.Select(m => new Token(row, m.Index, m.Value))
            );

            return tokens;
        }
        
    }
}
