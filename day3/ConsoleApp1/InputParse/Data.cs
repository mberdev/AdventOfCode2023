using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public class Game
    {
        public int GameIndex { get; set; }
        public List<Round> Rounds { get; set; } = new List<Round>();

    }

    public class Round
    {
        public int[] CountByColor { get; set; } = new int[3];

        public override string ToString()
        {
            return string.Join(",", CountByColor);
        }
    }
}
