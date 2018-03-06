using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class AssertionResult 
    {
        public AssertionResult(bool success, string successMessage, string failureMessage, params object[] args)
        {
            this.Success = success;
            this.SuccessMessage = successMessage;
            this.FailureMessage = failureMessage;
            this.Args = args;
        }

        public bool Success { get; private set; }
        public string SuccessMessage { get; private set; }
        public string FailureMessage { get; private set; }
        public object[] Args { get; private set; }
    }

    public class AssertEqualsResult : AssertionResult
    {
        public AssertEqualsResult(string expected, string actual, string successMessage, string failureMessage)
            : base(expected == actual, successMessage, failureMessage, expected, actual)
        {
            this.Expected = expected;
            this.Actual = actual;
        }

        public string Expected { get; private set; }
        public string Actual { get; private set; }
    }

    public class AssertElementResult : AssertionResult
    {
        public AssertElementResult(Element element, string successMessage, string failureMessage, params object[] args)
            : base(element != null, successMessage, failureMessage, args)
        {
            this.Element = element;
        }

        public Element Element { get; private set; }
    }
}
