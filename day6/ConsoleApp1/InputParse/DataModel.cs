
namespace ConsoleApp1.InputParse
{
    public class ValuesPair
    {
        public int Time { get; }
        public int Distance { get; }

        public ValuesPair(int time, int distance)
        {
            Time = time;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"{{Time: {Time}, Distance: {Distance}}}";
        }
    }
}
