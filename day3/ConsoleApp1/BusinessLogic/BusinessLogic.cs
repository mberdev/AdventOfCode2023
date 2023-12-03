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
        public static bool RoundBreaksLogic(Round r)
        {
                return r.CountByColor[0] > Limits.MaxPerColor[0] ||
                r.CountByColor[1] > Limits.MaxPerColor[1] ||
                r.CountByColor[2] > Limits.MaxPerColor[2];
        }   

        public static bool GameBreaksLimits(Game r)
        {
            return r.Rounds.Any(RoundBreaksLogic);
        }

        public static int PowerOfRow(Game r)
        {
            var highestRed = HighestOfColor(r, ColorEnum.red);
            var highestGreen = HighestOfColor(r, ColorEnum.green);
            var highestBlue = HighestOfColor(r, ColorEnum.blue);
            return highestRed * highestGreen * highestBlue;
        }

        private static int HighestOfColor(Game r, ColorEnum color)
        {
            return r.Rounds.Select(x => x.CountByColor[(int) color]).Max();
        }
    }
}
