
namespace ConsoleApp1.InputParse
{
    public interface IConversionsStore
    {
        public Map[] Maps { get; }

    }
    public class Almanach_Part1 : IConversionsStore
    {
        public List<long> Seeds { get; } = new();
        public Map[] Maps { get; } = new Map[Enum.GetValues(typeof(Sections)).Length];

    }

    public class Almanach_Part2 : IConversionsStore
    {
        public List<SeedRange> SeedRanges { get; } = new();
        public Map[] Maps { get; } = new Map[Enum.GetValues(typeof(Sections)).Length];

    }

    public class SeedRange
    {
        public long Start { get; }
        public long Length { get; }

        public long End => Start + Length - 1;

        public SeedRange(long start, long length)
        {
            Start = start;
            Length = length;
        }
    }

    public enum Sections
    {
        seed = 0,
        soil = 1,
        fertilizer = 2,
        water = 3,
        light = 4,
        temperature = 5,
        humidity = 6,
        location = 7,
    }

    public class Map
    {
        //public string Key => $"{SourceName}-{DestinationName}";

        public Sections Source { get; }
        public Sections Destination { get; }
        public List<Range> Ranges { get; } = new();

        public Map(Sections source, Sections destination)
        {
            Source = source;
            Destination = destination;
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
