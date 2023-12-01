
using ConsoleApp1.InputParse;

var lines = LineBreakParser.ParseInput(Input.File);
lines.ToList().ForEach(l => Console.WriteLine(l));