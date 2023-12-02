using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public static class LineDataParser
    {
        public static Row ParseLine(string s)
        {
            Row row = new Row();

            var parts = s.Split(':');
            row.GameIndex = int.Parse(parts[0].Substring("Game ".Length));

            var roundsStr = parts[1].Split(';');

            foreach (var roundStr in roundsStr)
            {
                string[] colorValues = roundStr.Trim().Split(',');

                var colorsData = colorValues.Select(c => {
                    var parts = c.Trim().Split(' ');
                    var colorCount = int.Parse(parts[0]);
                    var color = ColorParser.ParseColor(parts[1]);
                    return new { Color = color, ColorCount = colorCount };
                });

                var colors = new int[3];
                foreach (ColorEnum c in Enumerable.Range(0, 3))
                {
                    var colorData = colorsData.FirstOrDefault(d => d.Color == c);
                    colors[(int)c] = colorData?.ColorCount ?? 0;
                }

                row.Rounds.Add(new Round() { CountByColor = colors });
            }

            return row;
        }
    }
}
