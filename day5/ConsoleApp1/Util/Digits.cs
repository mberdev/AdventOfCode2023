using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Util
{
    public static class Digits
    {
        public static string[] DigitWords = {
            "zero", "one", "two", "three", "four",
            "five", "six", "seven", "eight", "nine"
        };

        public static int WordDigitToInt(string s)
        {
            var index = Array.IndexOf(Digits.DigitWords, s);

            if (index == -1)
            {
                throw new ArgumentException($"'{s}' is not a digit word");
            }

            return index;
        }

    }
}
