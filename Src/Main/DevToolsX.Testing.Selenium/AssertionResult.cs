using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class AssertionResult 
    {
        private static readonly EventId AssertionEventId = new EventId();

        protected AssertionResult(bool success, string expected, string actual, string message)
        {
            this.Success = success;
            this.Message = string.Format(message, expected, actual);
            this.Expected = expected;
            this.Actual = actual;
        }

        public static AssertionResult Create(string expected, string actual, string message)
        {
            return new AssertionResult(expected == actual, expected, actual, message);
        }

        public static AssertionResult Create(bool success, string expected, string actual, string message)
        {
            return new AssertionResult(success, expected, actual, message);
        }

        public static AssertionResult Create(ILogger logger, string expected, string actual, string message)
        {
            return AssertionResult.Create(logger, expected == actual, expected, actual, message);
        }

        public static AssertionResult Create(ILogger logger, bool success, string expected, string actual, string message)
        {
            if (!success)
            {
                logger.LogError(message, expected, actual);
            }
            return AssertionResult.Create(success, expected, actual, message);
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string Expected { get; private set; }
        public string Actual { get; private set; }
    }
}
