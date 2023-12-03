
namespace ConsoleApp1.InputParse
{

    public class Token
    {
        public bool IsNumber { get; }
        public bool IsSymbol => !IsNumber;

        private int _asNumber;
        public int AsNumber => IsNumber ? _asNumber : throw new Exception("Not a number");

        public int Row { get; }
        public int Start { get; }
        public int End { get; }

        public string Value { get; }

        public List<Token> Neighbours{ get; } = new ();

        public Token(int row, int index, string value)
        {
            Row = row;
            Start = index;
            End = index + value.Length -1;
            Value = value;
            IsNumber = int.TryParse(value, out var iValue);
            _asNumber = IsNumber ? iValue : -1;
        }
    }

    public class TokensMap
    {
        public List<Token> Tokens { get; } = new ();

        public List<Token> TokensByRow(int row) => Tokens.Where(t => t.Row == row).ToList();
    }
}
