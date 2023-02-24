namespace RomanNumbersCalculator.Models
{
    internal class NodeNumber : Node
    {
        public NodeNumber(int number)
        {
            _number = number;
        }

        private int _number;

        public override int Eval()
        {
            return _number;
        }
    }
}