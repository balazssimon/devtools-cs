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

    public class AssertExpectedResult : AssertionResult
    {
        public AssertExpectedResult(bool success, string expected, string actual, string successMessage, string failureMessage)
            : base(success, successMessage, failureMessage, expected, actual)
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
            : base(element.Exists, successMessage, failureMessage, args)
        {
            this.Element = element;
        }

        public Element Element { get; private set; }
    }

    public class AssertFormResult : AssertionResult
    {
        public AssertFormResult(Form form, string successMessage, string failureMessage, params object[] args)
            : base(form.Exists, successMessage, failureMessage, args)
        {
            this.Form = form;
        }

        public Form Form { get; private set; }
    }

    public class AssertRadioGroupResult : AssertionResult
    {
        public AssertRadioGroupResult(RadioGroup radioGroup, string successMessage, string failureMessage, params object[] args)
            : base(radioGroup.Exists, successMessage, failureMessage, args)
        {
            this.RadioGroup = radioGroup;
        }

        public RadioGroup RadioGroup { get; private set; }
    }

    public class AssertListResult : AssertionResult
    {
        public AssertListResult(List list, string successMessage, string failureMessage, params object[] args)
            : base(list.Exists, successMessage, failureMessage, args)
        {
            this.List = list;
        }

        public List List { get; private set; }
    }

    public class AssertTableResult : AssertionResult
    {
        public AssertTableResult(Table table, string successMessage, string failureMessage, params object[] args)
            : base(table.Exists, successMessage, failureMessage, args)
        {
            this.Table = table;
        }

        public Table Table { get; private set; }
    }
}
