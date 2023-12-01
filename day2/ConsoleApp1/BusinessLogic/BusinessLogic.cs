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
        private static string pattern = $"(?:[0-9]|{string.Join("|", Digits.DigitWords)})";
        private static Regex r_LeftToRight = new Regex(pattern, RegexOptions.None);
        private static Regex r_RightToLeft = new Regex(pattern, RegexOptions.RightToLeft);

        private static string[] FindDigits_LeftToRight(string s)
        {
            MatchCollection matches = r_LeftToRight.Matches(s);
            return matches.ToArray().Select(m => m.Value).ToArray();
        }

        private static string[] FindDigits_RightToLeft(string s)
        {
            MatchCollection matches = r_RightToLeft.Matches(s);
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
            var first = FindDigits_LeftToRight(s).First();
            var last = FindDigits_RightToLeft(s).First();
            var firstAsInt  = DigitToInt(first);
            var lastAsInt = DigitToInt(last);
            return int.Parse($"{firstAsInt}{lastAsInt}");
        }

    }
}
