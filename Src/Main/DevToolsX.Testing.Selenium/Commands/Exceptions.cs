using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class WebTestingException : Exception
    {
        private static readonly object[] EmptyObjectArray = new object[0];

        public WebTestingException()
        {
            this.RawArgs = EmptyObjectArray;
        }

        public WebTestingException(string message, params object[] args)
            : base(string.Format(message, args))
        {
            this.RawMessage = message;
            this.RawArgs = args;
        }

        public WebTestingException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.RawMessage = message;
            this.RawArgs = args;
        }

        public string RawMessage { get; }
        public object[] RawArgs { get; set; }
    }

    public class AssertionException : Exception
    {
        private static readonly object[] EmptyObjectArray = new object[0];

        public AssertionException()
        {
            this.RawArgs = EmptyObjectArray;
        }

        public AssertionException(string message, params object[] args)
            : base(string.Format(message, args))
        {
            this.RawMessage = message;
            this.RawArgs = args;
        }

        public AssertionException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            this.RawMessage = message;
            this.RawArgs = args;
        }

        public string RawMessage { get; }
        public object[] RawArgs { get; }
    }

    public class AssertEqualsException : AssertionException
    {
        public AssertEqualsException(string expected, string actual)
        {
            this.Expected = expected;
            this.Actual = actual;
        }

        public AssertEqualsException(string expected, string actual, string message, params object[] args)
            : base(message, args)
        {
            this.Expected = expected;
            this.Actual = actual;
        }

        public AssertEqualsException(Exception innerException, string expected, string actual, string message, params object[] args)
            : base(innerException, message, args)
        {
            this.Expected = expected;
            this.Actual = actual;
        }

        public string Expected { get; }
        public string Actual { get; }
    }

    public class AssertElementException : AssertionException
    {
        public AssertElementException(Element element)
        {
            this.Element = element;
        }

        public AssertElementException(Element element, string message, params object[] args)
            : base(message, args)
        {
            this.Element = element;
        }

        public AssertElementException(Exception innerException, Element element, string message, params object[] args)
            : base(innerException, message, args)
        {
            this.Element = element;
        }

        public Element Element { get; }
    }
}
