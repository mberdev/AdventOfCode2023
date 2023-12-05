
namespace ConsoleApp1.InputParse
{
    public class Almanach
    {
        public List<long> Seeds { get; } = new();
        public Dictionary<string, Map> Maps { get; } = new();

    }

    public class Map
    {
        public string Key => $"{SourceName}-{DestinationName}";

        public string SourceName { get; }
        public string DestinationName { get; }
        public List<Range> Ranges { get; } = new();

        public Map(string sourceName, string destinationName)
        {
            SourceName = sourceName;
            DestinationName = destinationName;
        }
    }

    public class Range
    {
        public long DestinationStart { get; }
        public long SourceStart { get; }
        public long RangeLength { get; }

        public Range(long destinationStart, long sourceStart, long rangeLength)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            RangeLength = rangeLength;
        }
    }
}
