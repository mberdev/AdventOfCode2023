using ConsoleApp1.InputParse;
using ConsoleApp1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.BusinessLogic
{
    public static class BusinessLogic
    {
        private static bool TokensAreAdjacent(Token token1, Token token2)
        {
            if (token1.End >= token2.Start - 1 && token1.Start <= token2.End + 1)
                return true;

            if (token2.End >= token1.Start - 1 && token2.Start <= token1.End + 1)
                return true;

            return false;
        }

        public static List<Token> NumbersAdjacentToSymbol(TokensMap map, Token symbol)
        {
            // Mild optimization. Only numbers from the line above, same line or line below.
            var narrowedDown = map.Tokens.Where(t => t.IsNumber && t.Row >= symbol.Row - 1 && t.Row <= symbol.Row + 1);

            return narrowedDown.Where(number => TokensAreAdjacent(symbol, number)).ToList();

        }
    }
}
