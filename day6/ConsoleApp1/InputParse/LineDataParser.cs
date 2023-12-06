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

        public static List<Record> Parse_Part1(string times, string distances)
        {
            var strTimes = times.Split(' ').Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var strDistances = distances.Split(' ').Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

            return strTimes.Zip(strDistances, (time, distance) => new Record(int.Parse(time), int.Parse(distance))).ToList();
        }

        public static Record Parse_Part2(string times, string distances)
        {
            var strTimes = times.Split(' ').Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var strTime = string.Join("", strTimes);
            var time = int.Parse(strTime);

            var strDistances = distances.Split(' ').Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var strDistance = string.Join("", strDistances);
            var distance = int.Parse(strDistance);

            return new Record(time, distance);
        }
    }
}
