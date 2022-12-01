using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logging
{
    class DbLogger : ILogger
    {
        public void Log(string logMessage) => LogMsgToDb(logMessage);

        private void LogMsgToDb(string logMsg)
        {
            throw new Exception("No connection");
        }
    }
}
