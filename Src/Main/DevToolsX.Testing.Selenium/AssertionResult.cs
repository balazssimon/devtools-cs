using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class AssertionResult 
    {
        public AssertionResult(string expected, string actual, string message)
            : this(expected == actual, expected, actual, message)
        {
        }

        public AssertionResult(bool success, string expected, string actual, string message)
        {
            this.Success = success;
            this.Message = string.Format(message, expected, actual);
            this.Expected = expected;
            this.Actual = actual;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string Expected { get; private set; }
        public string Actual { get; private set; }
    }
}
