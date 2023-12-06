﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public static class LineBreakParser
    {
        private static string[] ParseLines(string input)
        {
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return lines.Select(l => l.Trim()).ToArray();
        }

        public static string[] ParseInput(string input, bool leaveEmptyLines)
        {
            var lines = ParseLines(input);
            
            if (!leaveEmptyLines)
            {
                lines = lines.Where(l => !string.IsNullOrEmpty(l)).ToArray();
            }
            
            return lines;
        }
    }    
}
