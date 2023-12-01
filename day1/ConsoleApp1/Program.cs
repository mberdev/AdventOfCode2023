
using ConsoleApp1.BusinessLogic;
using ConsoleApp1.InputParse;
using System.Linq;

var lines = LineBreakParser.ParseInput(Input.File);
foreach (var line in lines)
{
    //Console.WriteLine($"{line} -> {BusinessLogic.FindRowDigits_v1(line)}");
}

var sum = lines.ToList().Select(l => BusinessLogic.FindRowDigits_v1(l)).Sum();
Console.WriteLine(sum);