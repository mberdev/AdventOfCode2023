
namespace ConsoleApp1.InputParse
{
    public class Record
    {
        public int Time { get; }
        public int Distance { get; }

        public Record(int time, int distance)
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
