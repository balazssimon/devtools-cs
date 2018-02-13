using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.Documents.Office
{
    public class ExcelReader : IDisposable
    {
        private Application excel = null;
        private Workbook workbook = null;
        private Worksheet worksheet = null;
        private Range range = null;

        public ExcelReader(string workbook, string worksheet)
        {
            try
            {
                excel = (Application)Marshal.GetActiveObject("Excel.Application");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Excel is not running. Please, open the workbook '" + workbook + "' in Excel.");
            }

            try
            {
                foreach (var item in excel.Workbooks)
                {
                    Workbook wb = (Workbook)item;
                    if (wb.Name == workbook)
                    {
                        this.workbook = wb;
                        break;
                    }
                }
            }
            catch(Exception)
            {
                this.Dispose();
                throw new InvalidOperationException("Workbook is not open. Please, open the workbook '" + workbook + "' in Excel.");
            }

            if (this.workbook == null)
            {
                this.Dispose();
                throw new InvalidOperationException("Workbook is not open. Please, open the workbook '" + workbook + "' in Excel.");
            }

            try
            {
                foreach (var item in this.workbook.Worksheets)
                {
                    Worksheet ws = (Worksheet)item;
                    if (ws.Name == worksheet)
                    {
                        this.worksheet = ws;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                this.Dispose();
                throw new InvalidOperationException("Could not find worksheet '" + worksheet + "' in workbook '" + workbook + "'.");
            }

            if (this.worksheet == null)
            {
                this.Dispose();
                throw new InvalidOperationException("Could not find worksheet '" + worksheet + "' in workbook '" + workbook + "'.");
            }

            try
            {
                this.range = this.worksheet.UsedRange;
            }
            catch (Exception)
            {
                this.Dispose();
                throw new InvalidOperationException("Could not access worksheet '" + worksheet + "' in workbook '" + workbook + "'.");
            }
        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(this.excel);
            this.excel = null;
        }

        public static bool WorksheetExists(string workbook, string worksheet)
        {
            try
            {
                using (new ExcelReader(workbook, worksheet))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int ColumnCount
        {
            get { return this.range.Columns.Count; }
        }

        public int RowCount
        {
            get { return this.range.Rows.Count; }
        }

        public object GetValue(int row, int col)
        {
            return this.range.Cells[row + 1, col + 1];
        }

        public string GetText(int row, int col)
        {
            return this.range.Cells[row + 1, col + 1].Text;
        }

        public string this[int row, int col]
        {
            get { return this.GetText(row, col); }
        }
    }
}
