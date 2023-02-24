using RomanNumbersCalculator.Dictionaries;
using RomanNumbersCalculator.Enums;
using System.Text;

namespace RomanNumbersCalculator.Sevices
{
    internal class ExpressionReader
    {
        public ExpressionReader(string input)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"Empty or white inputr data");
            }
            _reader = new StringReader(input);
            _romanNumbersToIntParser = new();
            NextChar();
            NextValue();
        }

        TextReader _reader;
        RomanNumbersToIntParser _romanNumbersToIntParser;
        char _currentChar;
        ExpressionValueType _currentDataType;
        int _number;

        public ExpressionValueType ExpressionValueType
        {
            get { return _currentDataType; }
        }

        public int Number
        {
            get { return _number; }
        }

        void NextChar()
        {
            int ch = _reader.Read();
            _currentChar = ch < 0 ? '\0' : (char)ch;
        }

        public void NextValue()
        {
            while (char.IsWhiteSpace(_currentChar))
            {
                NextChar();
            }

            switch (_currentChar)
            {
                case '\0':
                    _currentDataType = ExpressionValueType.EOF;
                    return;

                case '+':
                    NextChar();
                    _currentDataType = ExpressionValueType.Add;
                    return;

                case '-':
                    NextChar();
                    _currentDataType = ExpressionValueType.Subtract;
                    return;

                case '*':
                    NextChar();
                    _currentDataType = ExpressionValueType.Multiply;
                    return;

                case '/':
                    NextChar();
                    _currentDataType = ExpressionValueType.Divide;
                    return;

                case '(':
                    NextChar();
                    _currentDataType = ExpressionValueType.OpenParens;
                    return;

                case ')':
                    NextChar();
                    _currentDataType = ExpressionValueType.CloseParens;
                    return;
            }

            if(RomanNumbers.BasicRomanNumbers.TryGetValue(_currentChar, out _))
            {
                var sb = new StringBuilder();
                sb.Append(_currentChar);
                NextChar();
                while (RomanNumbers.BasicRomanNumbers.TryGetValue(_currentChar, out _))
                {
                    sb.Append(_currentChar);
                    NextChar();
                }

                _number = _romanNumbersToIntParser.Parse(sb.ToString());
                _currentDataType = ExpressionValueType.Number;
            }
        }
    }
}