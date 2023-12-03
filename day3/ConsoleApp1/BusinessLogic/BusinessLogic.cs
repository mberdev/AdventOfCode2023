using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.BusinessLogic
{
    public static class BusinessLogic
    {
        public static bool IsAdjacentToSymbol(NumberToken token, HashSet<int> symbolsCurrentRow, HashSet<int> symbolsRowAbove, HashSet<int> symbolsRowBelow)
        {
            var asString = token.Value.ToString();

            // Current line
            var positionBefore = token.Index - 1;
            var positionAfter = token.Index + asString.Length;
            var isAdj = symbolsCurrentRow.Contains(positionBefore) || symbolsCurrentRow.Contains(positionAfter);
            if (isAdj) return true;

            // Line above
            var range = Enumerable.Range(positionBefore, asString.Length + 2); // +2 for diagonals
            isAdj = range.Any(position => symbolsRowAbove.Contains(position));
            if (isAdj) return true;

            // Line below
            isAdj = range.Any(position => symbolsRowBelow.Contains(position));
            if (isAdj) return true;

            return false;
        }
    }
}
