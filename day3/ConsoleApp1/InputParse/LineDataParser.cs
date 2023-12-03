using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public static class LineDataParser
    {
        // TODO: This function would habe been greatly improved with a regular expression
        public static Game ParseGame(string s)
        {
            Game row = new Game();

            var parts = s.Split(':');
            row.GameIndex = int.Parse(parts[0].Substring("Game ".Length));

            var roundsStr = parts[1].Split(';');

            foreach (var roundStr in roundsStr)
            {
                Round round = ParseRound(roundStr);

                row.Rounds.Add(round);
            }

            return row;
        }

        private static Round ParseRound(string roundStr)
        {
            string[] colorValues = roundStr.Trim().Split(',');

            var colorsData = colorValues.Select(c =>
            {
                string[] parts = c.Trim().Split(' ');
                var colorCount = int.Parse(parts[0]);
                var color = ColorParser.ParseColor(parts[1]);
                var colorData =  new { Color = color, ColorCount = colorCount };
                return colorData;
            });

            var colors = new int[3];
            foreach (ColorEnum c in Enumerable.Range(0, 3))
            {
                var colorData = colorsData.FirstOrDefault(d => d.Color == c);
                colors[(int)c] = colorData?.ColorCount ?? 0;
            }

            var round = new Round() { CountByColor = colors };
            return round;
        }
    }
}
