using Moq;
using System;

namespace Calculator.Tests.Moq
{
    static class CalculatorMoqFactory
    {
        public static ICalculator Order(decimal returnValue)
        {
            var mock = new Mock<ICalculator>();
            mock.Setup(x => x.Add(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(returnValue);
            mock.Setup(x => x.Devide(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(returnValue);
            mock.Setup(x => x.Devide(It.IsAny<decimal>(), 0)).Throws<DivideByZeroException>();
            mock.Setup(x => x.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(returnValue);
            mock.Setup(x => x.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(returnValue);
            mock.Setup(x => x.Add(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(returnValue);
            return mock.Object;
        }
    }
}
