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

        public static bool RowBreaksLogic(Row r)
        {
            return r.Rounds.Any(RoundBreaksLogic);
        }

    }
}
