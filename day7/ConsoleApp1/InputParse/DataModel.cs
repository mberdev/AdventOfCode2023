
namespace ConsoleApp1.InputParse
{
    public class Record
    {
        public int Time { get; }
        public long Distance { get; }

        public Record(int time, long distance)
        {
            Time = time;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"{{Time: {Time}, Distance: {Distance}}}";
        }
    }

    public class Race
    {
        public int TimeLimit { get; }

        public Race(int timeLimit)
        {
            TimeLimit = timeLimit;
        }

    }
}
