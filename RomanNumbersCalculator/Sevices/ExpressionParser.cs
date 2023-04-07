using RomanNumbersCalculator.Enums;
using RomanNumbersCalculator.Models;

namespace RomanNumbersCalculator.Sevices
{
    internal class ExpressionParser
    {
        public ExpressionParser(ExpressionReader expressionReader)
        {
            _expressionReader = expressionReader;
        }

        ExpressionReader _expressionReader;

        public Node ParseExpression()
        {
            var expr = ParseAddSubtract();

            if (_expressionReader.ExpressionValueType != ExpressionValueType.EOF)
                throw new Exception("Unexpected characters at end of expression");

            return expr;
        }

        Node ParseAddSubtract()
        {
            var lhs = ParseMultiplyDivide();

            while (true)
            {
                Func<int, int, int> op = null;
                if (_expressionReader.ExpressionValueType == ExpressionValueType.Add)
                {
                    op = (a, b) => a + b;
                }
                else if (_expressionReader.ExpressionValueType == ExpressionValueType.Subtract)
                {
                    op = (a, b) => a - b;
                }

                if (op == null)
                    return lhs;

                _expressionReader.NextValue();

                var rhs = ParseMultiplyDivide();

                lhs = new NodeBinarys(lhs, rhs, op);
            }
        }

        Node ParseMultiplyDivide()
        {
            var lhs = ParseLeaf();

            while (true)
            {
                Func<int, int, int> op = null;
                if (_expressionReader.ExpressionValueType == ExpressionValueType.Multiply)
                {
                    op = (a, b) => a * b;
                }
                else if (_expressionReader.ExpressionValueType == ExpressionValueType.Divide)
                {
                    op = (a, b) => a / b;
                }

                if (op == null)
                    return lhs;

                _expressionReader.NextValue();

                var rhs = ParseLeaf();

                lhs = new NodeBinary(lhs, rhs, op);
            }
        }

        Node ParseLeaf()
        {
            if (_expressionReader.ExpressionValueType == ExpressionValueType.Number)
            {
                var node = new NodeNumber(_expressionReader.Number);
                _expressionReader.NextValue();
                return node;
            }

            if (_expressionReader.ExpressionValueType == ExpressionValueType.OpenParens)
            {
                _expressionReader.NextValue();

                var node = ParseAddSubtract();

                if (_expressionReader.ExpressionValueType != ExpressionValueType.CloseParens)
                    throw new Exception("Missing close parenthesis");
                _expressionReader.NextValue();

                return node;
            }

            throw new Exception($"Unexpect ExpressionValueType: {_expressionReader.ExpressionValueType}");
        }
    }
}