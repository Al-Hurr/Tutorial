
using Calculator.Logging;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        private ILogger _logger;
        private ICalculator _calculator;

        public Calculator(ILogger logger, ICalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        public decimal Add(decimal a, decimal b)
        {
            _logger.Log("Add");
            return _calculator.Add(a, b);
        }

        public decimal Devide(decimal a, decimal b)
        {
            _logger.Log("Devide");
            return _calculator.Devide(a, b);
        }

        public decimal Multiply(decimal a, decimal b)
        {
            _logger.Log("Multiply");
            return _calculator.Multiply(a, b);
        }

        public decimal Subtract(decimal a, decimal b)
        {
            _logger.Log("Subtract");
            return _calculator.Subtract(a, b);
        }
    }
}
