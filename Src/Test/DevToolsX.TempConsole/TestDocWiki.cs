using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevToolsX.Testing.Selenium; //4:1

namespace DevToolsX.TempConsole //1:1
{
    using __Hidden_TestDocWiki_1400801208;
    namespace __Hidden_TestDocWiki_1400801208
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


    public class TestDocWiki : TestWikiGenerator //2:1
    {
        public TestDocWiki() //2:1
        {
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

        protected override string ProcessTemplateOutput(object output) //2:1
        {
            return base.ProcessTemplateOutput(output);
        }

        public string OpenPage(string url, string search) //6:1
        {
            StringBuilder __out = new StringBuilder();
            Element input; //7:2
            Element searchButton; //8:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "Open page '"; //9:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(this.ProcessTemplateOutput(url));
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
            string __tmp5_line = "' in the browser: "; //9:17
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            Browser.GoToUrl(url); //9:36
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //9:62
            }
            __out.AppendLine(true); //10:1
            bool __tmp8_outputWritten = false;
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(this.ProcessTemplateOutput(Screenshot.TakeScreenshot()));
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
                __out.AppendLine(false); //11:30
            }
            __out.AppendLine(true); //12:1
            __out.Append(this.ProcessTemplateOutput("<br/>")); //13:1
            __out.AppendLine(false); //13:6
            __out.AppendLine(true); //14:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "The page title should be "; //15:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(this.ProcessTemplateOutput(Browser.TitleShouldBe("Google")));
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
            string __tmp14_line = "."; //15:59
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //15:60
            }
            __out.AppendLine(true); //16:1
            input = Page.FindElement("name:q");
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "Type '"; //18:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(this.ProcessTemplateOutput(search));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = "' into the search box: "; //18:15
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            input.TypeText(search); //18:39
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //18:67
            }
            __out.AppendLine(true); //19:1
            input.Mark(); //20:2
            Wait.For(TimeSpan.FromSeconds(3)); //21:2
            bool __tmp22_outputWritten = false;
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(this.ProcessTemplateOutput(Screenshot.TakeScreenshot()));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp23_last || __tmp22_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //22:30
            }
            input.Unmark(); //23:2
            __out.AppendLine(true); //24:1
            searchButton = Page.FindElements("xpath://input[@class='lsb']")[0];
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "Press the <b>"; //26:1
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp25_outputWritten = true;
            }
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(this.ProcessTemplateOutput(searchButton.Value));
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    string __tmp27_line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                    {
                        __out.Append(__tmp27_line);
                        __tmp25_outputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp28_line = "</b> button:"; //26:34
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //26:46
            }
            __out.AppendLine(true); //27:1
            searchButton.Mark(); //28:2
            bool __tmp30_outputWritten = false;
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(this.ProcessTemplateOutput(Screenshot.TakeScreenshot()));
            using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
            {
                bool __tmp31_last = __tmp31Reader.EndOfStream;
                while(!__tmp31_last)
                {
                    string __tmp31_line = __tmp31Reader.ReadLine();
                    __tmp31_last = __tmp31Reader.EndOfStream;
                    if ((__tmp31_last && !string.IsNullOrEmpty(__tmp31_line)) || (!__tmp31_last && __tmp31_line != null))
                    {
                        __out.Append(__tmp31_line);
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp31_last || __tmp30_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //29:30
            }
            searchButton.Unmark(); //30:2
            __out.AppendLine(true); //31:1
            searchButton.Click(); //32:2
            Wait.For(TimeSpan.FromSeconds(3)); //33:2
            __out.AppendLine(true); //34:1
            bool __tmp33_outputWritten = false;
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(this.ProcessTemplateOutput(Screenshot.TakeScreenshot()));
            using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
            {
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    string __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                    {
                        __out.Append(__tmp34_line);
                        __tmp33_outputWritten = true;
                    }
                    if (!__tmp34_last || __tmp33_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //35:30
            }
            __out.AppendLine(true); //36:1
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
