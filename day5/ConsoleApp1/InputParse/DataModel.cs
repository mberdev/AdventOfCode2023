
namespace ConsoleApp1.InputParse
{
    public class Almanach
    {
        public List<int> Seeds { get; } = new();
        public Dictionary<string, Map> Maps { get; } = new();

    }

    public class Map
    {
        public string Name { get; }
        public List<Range> Ranges { get; } = new();

        public Map(string name)
        {
            Name = name;
        }
    }

    public class Range
    {
        public int DestinationStart { get; }
        public int SourceStart { get; }
        public int RangeLength { get; }

        public Range(int destinationStart, int sourceStart, int rangeLength)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            RangeLength = rangeLength;
        }
    }
}
