using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.InputParse
{
    public class StringSeparator
    {
        // Breaks a series of strings into groups of strings
        // where each group is separated by one or more empty strings
        public static List<List<string>> Separate(List<string> input)
        {
            var result = new List<List<string>>();
            var currentGroup = new List<string>();

            foreach (var str in input)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    //End of a group
                    if (currentGroup.Count > 0)
                    {
                        result.Add(currentGroup);
                        currentGroup = new List<string>();
                    }
                }
                else
                {
                    //Ongoing group
                    currentGroup.Add(str);
                }
            }

            // End of final group  
            if (currentGroup.Count > 0)
            {
                result.Add(currentGroup);
            }

            return result;
        }
    }
}
