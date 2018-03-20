using DevToolsX.Documents.Symbols;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.Documents
{

    public interface IDocumentWriter
    {
        void BeginDocument();
        void EndDocument();

        void AddTableOfContents(int depth);

        void PageBreak();
        void LineBreak();

        void BeginSectionTitle(int level, string label);
        void EndSectionTitle(int level, string label);

        void BeginParagraph();
        void Write(string text);
        void WriteLine();
        void EndParagraph();

        void BeginMarkup(IEnumerable<MarkupKind> markupKind, Color foregroundColor, Color backgroundColor);
        void EndMarkup(IEnumerable<MarkupKind> markupKind, Color foregroundColor, Color backgroundColor);

        void AddLabel(string id);

        void BeginReference(string document, string id);
        void EndReference(string document, string id);

        void BeginList(int level, ListKind listKind);
        void EndList(int level, ListKind listKind);
        void BeginListItem(int level, int index, string title);
        void EndListItem(int level, int index, string title);

        void BeginTable(int colCount);
        void BeginTableRow(int rowIndex);
        void EndTableRow(int index);
        void BeginTableCell(int rowIndex, int colIndex, bool head);
        void EndTableCell(int rowIndex, int colIndex, bool head);
        void EndTable(int colCount);

        void AddImage(string path);
    }
}
