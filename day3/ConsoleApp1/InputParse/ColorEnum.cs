using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public enum ColorEnum

    {
        red = 0,
        green = 1,
        blue = 2
    }

    public static class ColorParser
    {
        public static ColorEnum ParseColor(string s)
        {
            return (ColorEnum)Enum.Parse(typeof(ColorEnum), s);
        }
    }
}
