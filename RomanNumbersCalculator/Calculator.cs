using RomanNumbersCalculator.Sevices;

namespace RomanNumbersCalculator
{
    public class Calculator
    {
        public string Evaluate(string input)
        {
            try
            {
                var expressionReader = new ExpressionReader(input);
                var expressionParser = new ExpressionParser(expressionReader);
                int result = expressionParser.ParseExpression().Eval();
                return new IntToRomanNumbersParser().Parse(result);
            }
            catch
            {
                throw;
            }
        }
    }
}