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
                var list = item as List;
                var childContainer = item as ContentContainer;
                if (sectionTitle != null) this.Print(sectionTitle);
                else if (paragraph != null) this.Print(paragraph);
                else if (text != null) this.Print(text);
                else if (markup != null) this.Print(markup);
                else if (list != null) this.Print(list);
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
            this.generator.BeginMarkup(markup.Kind);
            ContentContainer container = markup;
            this.Print(container);
            this.generator.EndMarkup();
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

    }
}
