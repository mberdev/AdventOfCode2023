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
        public static (List<NumberToken> numbers, HashSet<int> symbols) ParseTokens(string input)
        {
            var numbers = new List<NumberToken>();
            var symbols = new HashSet<int>();

            // Parsing integers
            MatchCollection intMatches = Regex.Matches(input, @"\d+");
            foreach (Match match in intMatches)
            {
                int value = int.Parse(match.Value);
                int index = match.Index;
                numbers.Add(new NumberToken(index, value));
            }

            // Parsing one-character symbols
            string symbolsPattern = @"[^.\s\d]";
            MatchCollection symbolMatches = Regex.Matches(input, symbolsPattern);
            foreach (Match match in symbolMatches)
            {
                symbols.Add(match.Index);
            }

            return (numbers, symbols);
        }
        
    }
}
