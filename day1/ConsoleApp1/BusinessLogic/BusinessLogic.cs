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
        private static string[] FindDigits(string s, RegexOptions option)
        {
            string pattern = @"(?:[0-9]|zero|one|two|three|four|five|six|seven|eight|nine)";
            var r = new Regex(pattern, option);
            MatchCollection matches = r.Matches(s);
            return matches.ToArray().Select(m => m.Value).ToArray();
        }

        private static int SingleDigitToInt(string s)
        {
            return int.Parse($"{s}");
        }



        private static int DigitToInt(string s)
        {
            return s.Length == 1 ? SingleDigitToInt(s) : Digits.WordDigitToInt(s);
        }


        public static int FindRowDigits_v1(string s)
        {
            var first = FindDigits(s, RegexOptions.None).First();
            var last = FindDigits(s, RegexOptions.RightToLeft).First();
            var firstAsInt  = DigitToInt(first);
            var lastAsInt = DigitToInt(last);
            return int.Parse($"{firstAsInt}{lastAsInt}");
        }

    }
}
