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
        private class StateMachine
        {
            static string[] sections = { "seed", "soil", "fertilizer", "water", "light", "temperature", "humidity", "location" };

            public string CurrentSection { get; private set; } = "seed";
            public bool IsHeader { get; private set; } = true;

            public string NextSection()
            {
                var nextSection = sections.SkipWhile(s => s != CurrentSection).Skip(1).FirstOrDefault();

                // It was already the last section
                if (nextSection == null)
                    return CurrentSection;

                CurrentSection = nextSection;
                IsHeader = true;
                return CurrentSection;
            }

            public void NextState(string line)
            {
                if (IsHeader)
                {
                    IsHeader = false;
                } else if (string.IsNullOrWhiteSpace(line)) {
                    NextSection();
                }
            }
        }



        public static Almanach Parse(List<string> input)
        {

            var state = new StateMachine();

            var almanach = new Almanach();

            foreach (var line in input)
            {
                ParseLine(state, almanach, line);
            }

            return almanach;
        }

        private static IEnumerable<int> ParseSeedsHeader(string line)
        {
            var parts = line.Split(' ');
            return parts.Skip(1).Select(int.Parse);
        }

        private static void ParseLine(StateMachine state, Almanach almanach, string line)
        {
            if (state.IsHeader)
            {
                if (state.CurrentSection == "seed")
                {
                    almanach.Seeds.AddRange(ParseSeedsHeader(line));

                }
                else
                {
                    almanach.Maps.Add(state.CurrentSection, new Map(state.CurrentSection));
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var map = almanach.Maps[state.CurrentSection];
                    map.Ranges.Add(ParseRange(line));
                }
            }

            state.NextState(line);
        }

        private static Range ParseRange(string line)
        {
            var values = line.Split(' ').Select(int.Parse).ToArray();
            return new Range(values[0], values[1], values[2]);
        }



    }
}
