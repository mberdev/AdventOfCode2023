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
        public static int DoRace(Race r, int holdTime)
        {
            if (holdTime >= r.TimeLimit)
                return 0;

            if (holdTime == 0)
                return 0;

            var initialSpeed = holdTime;
            var remainingTime = r.TimeLimit - holdTime;
            var distance = remainingTime * initialSpeed;

            return distance;
        }

        public static bool IsRecordBeaten(int myDistance, int recordDistance)
        {
            return myDistance > recordDistance;
        }
    }
}
