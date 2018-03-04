using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class AssertionResult
    {
        public AssertionResult(string expected, string actual)
        {
            this.Success = expected == actual;
            this.Expected = expected;
            this.Actual = actual;
        }

        public bool Success { get; private set; }
        public string Expected { get; private set; }
        public string Actual { get; private set; }
    }
}
