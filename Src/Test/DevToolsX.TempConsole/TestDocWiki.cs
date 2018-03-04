using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevToolsX.Testing.Selenium; //4:1

namespace DevToolsX.TempConsole //1:1
{
    using __Hidden_TestDocWiki_147666013;
    namespace __Hidden_TestDocWiki_147666013
    {
        internal static class __Extensions
        {
            internal static IEnumerator<T> GetEnumerator<T>(this T item)
            {
                if (item == null) return new List<T>().GetEnumerator();
                else return new List<T> { item }.GetEnumerator();
            }
        }
    }


    public class TestDocWiki //2:1
    {
        private IEnumerable<object> Instances; //2:1

        public TestDocWiki() //2:1
        {
            this.Properties = new __Properties();
        }

        public TestDocWiki(IEnumerable<object> instances) : this() //2:1
        {
            this.Instances = instances;
        }

        private Stream __ToStream(string text)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static IEnumerable<T> __Enumerate<T>(IEnumerator<T> items)
        {
            while (items.MoveNext())
            {
                yield return items.Current;
            }
        }

        private int counter = 0;
        private int NextCounter()
        {
            return ++counter;
        }

        public __Properties Properties { get; private set; } //6:1

        public class __Properties //6:1
        {
            internal __Properties()
            {
                this.Browser = null; //7:20
            }
            public Browser Browser { get; set; } //7:2
        }

        public string OpenPage(string url) //10:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "Open page '"; //11:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(url);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = "' in the browser: "; //11:17
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GoToUrl(url));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp6_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //11:49
            }
            __out.AppendLine(true); //12:1
            bool __tmp8_outputWritten = false;
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(Image(TakeScreenshot()));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp9_last || __tmp8_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp8_outputWritten)
            {
                __out.AppendLine(false); //13:26
            }
            __out.AppendLine(true); //14:1
            __out.Append("<br/>"); //15:1
            __out.AppendLine(false); //15:6
            __out.AppendLine(true); //16:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "The page title should be "; //17:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(AssertEquals("GoogleX", Properties.Browser.Title));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = "."; //17:77
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //17:78
            }
            return __out.ToString();
        }

        public string GoToUrl(string url) //20:1
        {
            Properties.Browser.GoToUrl(url); //21:2
            return ""; //22:2
        }

        public string TakeScreenshot() //25:1
        {
            return Properties.Browser.TakeScreenshot(); //26:2
        }

        public string Image(string filePath) //29:1
        {
            return "[[Media:" + filePath + "]]"; //30:2
        }

        public string AssertEquals(string expected, string actual) //33:1
        {
            StringBuilder __out = new StringBuilder();
            if (expected == actual) //34:2
            {
                bool __tmp2_outputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(expected);
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(!__tmp3_last)
                    {
                        string __tmp3_line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                        {
                            __out.Append(__tmp3_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //35:11
                }
            }
            else //36:2
            {
                bool __tmp5_outputWritten = false;
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(expected);
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6_line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                        {
                            __out.Append(__tmp6_line);
                            __tmp5_outputWritten = true;
                        }
                        if (!__tmp6_last) __out.AppendLine(true);
                    }
                }
                string __tmp7_line = "<span style=\"background:#FF8080; text-decoration:line-through\">"; //37:11
                if (!string.IsNullOrEmpty(__tmp7_line))
                {
                    __out.Append(__tmp7_line);
                    __tmp5_outputWritten = true;
                }
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(actual);
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(!__tmp8_last)
                    {
                        string __tmp8_line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                        {
                            __out.Append(__tmp8_line);
                            __tmp5_outputWritten = true;
                        }
                        if (!__tmp8_last) __out.AppendLine(true);
                    }
                }
                string __tmp9_line = "</span>"; //37:82
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Append(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (__tmp5_outputWritten) __out.AppendLine(true);
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //37:89
                }
            }
            return __out.ToString();
        }

        private class StringBuilder
        {
            private bool newLine;
            private System.Text.StringBuilder builder = new System.Text.StringBuilder();
            
            public StringBuilder()
            {
                this.newLine = true;
            }
            
            public void Append(string str)
            {
                if (str == null) return;
                if (!string.IsNullOrEmpty(str))
                {
                    this.newLine = false;
                }
                builder.Append(str);
            }
            
            public void Append(object obj)
            {
                if (obj == null) return;
                string text = obj.ToString();
                this.Append(text);
            }
            
            public void AppendLine(bool force = false)
            {
                if (force || !this.newLine)
                {
                    builder.AppendLine();
                    this.newLine = true;
                }
            }
            
            public override string ToString()
            {
                return builder.ToString();
            }
        }
    }
}
