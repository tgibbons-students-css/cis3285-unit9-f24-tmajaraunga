using System;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            LogMessage("WARN", message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            LogMessage("INFO", message, args);
        }

        private void LogMessage(string type, string message, params object[] args)
        {
            // Log to console
            Console.WriteLine($"{type}: {string.Format(message, args)}");

            // Log to XML file
            using (StreamWriter logfile = new StreamWriter("log.xml", append: true))
            {
                string formattedMessage = string.Format(message, args);
                logfile.WriteLine($"<log><type>{type}</type><message>{formattedMessage}</message></log>");
            }
        }
    }
}