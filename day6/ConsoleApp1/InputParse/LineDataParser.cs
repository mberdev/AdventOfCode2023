using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public class DataParser
    {

        public static List<Record> Parse(string times, string distances)
        {
            var strTimes = times.Split(' ').Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var strDistances = distances.Split(' ').Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

            return strTimes.Zip(strDistances, (time, distance) => new Record(int.Parse(time), int.Parse(distance))).ToList();
        }
    }
}
