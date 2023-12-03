
namespace ConsoleApp1.InputParse
{
    public class NumberToken
    {
        public int Index { get; set; }
        public int Value { get; set; }

        public NumberToken(int index, int value)
        {
            Index = index;
            Value = value;
        }

        public override string ToString()
        {
            return $"({Index}, {Value})";
        }
    }
}
