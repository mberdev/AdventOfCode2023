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
        public static List<int> FindWins(List<int> myNumbers, List<int> winningNumbers)
        {
            return myNumbers.Intersect(winningNumbers).ToList();
        }

        public static int CountPoints(List<int> wins)
        {
            if (wins.Count == 0)
                return 0;

            return (int)Math.Pow(2, wins.Count -1);
        }
    }
}
