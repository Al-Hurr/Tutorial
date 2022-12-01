
using Calculator.Logging;
using Moq;

namespace Calculator.Tests.Moq
{
    static class LoggerMoqFactory
    {
        public static ILogger Order()
        {
            var mock = new Mock<ILogger>();
            mock.Setup(x => x.Log(It.IsAny<string>())).Verifiable();
            return mock.Object;
        }
    }
}
