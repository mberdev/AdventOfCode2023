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

        public static List<Round> Parse(string[] input)
        {
            return input.Select(row =>
            {
                var split = row.Split(' ').ToList();
                var cardValues = split[0].Select(x => CardValuesParser.Parse(x)).ToList();
                var bid = int.Parse(split[1]);
                return new Round(cardValues, bid);
            })
            .ToList();
        }

    }
}
