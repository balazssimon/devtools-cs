using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DevToolsX.Documents.Symbols;

namespace DevToolsX.Documents
{
    public class DocumentModelPrinter : IDisposable
    {
        private ImmutableModel model;
        private DocumentGenerator generator;

        public DocumentModelPrinter(ImmutableModel model, DocumentGenerator generator)
        {
            this.model = model;
            this.generator = generator;
        }

        public void Dispose()
        {
            generator.Dispose();
        }

        public void Print()
        {
            foreach (var document in model.Symbols.OfType<Document>())
            {
                this.Print(document);
            }
        }

        private void Print(ContentContainer container)
        {
            foreach (var item in container.Text)
            {
                var sectionTitle = item as SectionTitle;
                var paragraph = item as Paragraph;
                var text = item as Text;
                var markup = item as Markup;
                var reference = item as Reference;
                var list = item as List;
                var table = item as Table;
                var image = item as Image;
                var lineBreak = item as LineBreak;
                var pageBreak = item as PageBreak;
                var childContainer = item as ContentContainer;
                if (sectionTitle != null) this.Print(sectionTitle);
                else if (paragraph != null) this.Print(paragraph);
                else if (text != null) this.Print(text);
                else if (markup != null) this.Print(markup);
                else if (reference != null) this.Print(reference);
                else if (list != null) this.Print(list);
                else if (table != null) this.Print(table);
                else if (image != null) this.Print(image);
                else if (lineBreak != null) this.Print(lineBreak);
                else if (pageBreak != null) this.Print(pageBreak);
                else if (childContainer != null) this.Print(childContainer);
            }
        }

        private void Print(SectionTitle title)
        {
            this.generator.WriteSectionTitle(title.Level, title.Title);
        }

        private void Print(Paragraph paragraph)
        {
            ContentContainer container = paragraph;
            this.Print(container);
            this.generator.WriteLine();
        }

        private void Print(Text text)
        {
            this.generator.Write(text.Text);
        }

        private void Print(Markup markup)
        {
            this.generator.BeginMarkup(markup.Kind, markup.ForegroundColor, markup.BackgroundColor);
            ContentContainer container = markup;
            this.Print(container);
            this.generator.EndMarkup();
        }

        private void Print(Reference reference)
        {
            this.generator.BeginReference(reference.DocumentName, reference.LabelName);
            ContentContainer container = reference;
            this.Print(container);
            this.generator.EndReference();
        }

        private void Print(List list)
        {
            this.generator.BeginList();
            foreach (var item in list.Items)
            {
                this.generator.AddListItem(item.Title);
                this.Print(item);
            }
            this.generator.EndList();
        }

        private void Print(Table table)
        {
            this.generator.BeginTable(table.ColumnCount, table.HeadColumnCount, table.HeadRowCount);
            foreach (var cell in table.Cells)
            {
                this.generator.AddTableCell();
                this.Print(cell);
            }
            this.generator.EndTable();
        }

        private void Print(Image image)
        {
            this.generator.AddImage(image.FilePath);
        }

        private void Print(LineBreak lineBreak)
        {
            this.generator.LineBreak();
        }

        private void Print(PageBreak pageBreak)
        {
            this.generator.NewPage();
        }


    }
}
