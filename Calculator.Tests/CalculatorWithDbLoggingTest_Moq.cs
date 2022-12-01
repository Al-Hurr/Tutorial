using AutoFixture;
using Calculator.Logging;
using Calculator.Tests.Moq;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorWithDbLoggingTest_Moq
    {
        private static Fixture _fixture = new Fixture();

        private ICalculator _systemUnderTests;
        private ICalculator _calculator;
        private ILogger _logger;
        private decimal _returnValue;

        [SetUp]
        public void Setup()
        {
            _returnValue = _fixture.Create<decimal>();
            _calculator = CalculatorMoqFactory.Order(_returnValue);
            _logger = LoggerMoqFactory.Order();
            _systemUnderTests = new Calculator(_logger, _calculator);
        }

        [Test]
        public void IfAddIsInvokedThenCorrectValueIsReturned()
        {
            var actual = _systemUnderTests.Add(2, 3);
            Assert.AreEqual(_returnValue, actual);
        }

        [Test]
        public void IfDevideIsInvokedThenCorrectValueIsReturned()
        {
            var actual = _systemUnderTests.Devide(2, 3);
            Assert.AreEqual(_returnValue, actual);
        }

        [Test]
        public void IfMultiplyIsInvokedThenCorrectValueIsReturned()
        {
            var actual = _systemUnderTests.Multiply(2, 3);
            Assert.AreEqual(_returnValue, actual);
        }

        [Test]
        public void IfSubtractIsInvokedThenCorrectValueIsReturned()
        {
            var actual = _systemUnderTests.Subtract(2, 3);
            Assert.AreEqual(_returnValue, actual);
        }
    }
}
