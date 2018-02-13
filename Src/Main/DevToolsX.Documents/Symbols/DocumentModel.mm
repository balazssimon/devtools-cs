namespace DevToolsX.Documents.Symbols
{
	metamodel DocumentModel(Uri="http://devtoolsx.documents.documentmodel/1.0"); 

	class Document
	{
		string Title;
		list<Section> Sections;
	}

	class Section
	{
		string Title;
		list<Section> Subsections;
		list<Paragraph> Paragraphs;
	}

	enum MarkupKind
    {
        None,
        Bold,
        Italic,
        Underline,
        Code,
        CodeInline,
        SubScript,
        SuperScript,
        Strikethrough
    }

    enum HorizontalAlignment
    {
        Default,
        Justify,
        Left,
        Center,
        Right
    }

	abstract class Content
	{
	}

	class ContentList : Content
	{
		list<Content> Items;
	}

	class Paragraph : Content
	{
		HorizontalAlignment Alignment;
		Content Text;
	}

	class Text : Content
	{
		string Text;
	}

	class Label : Content
	{
		string Name;
	}

	class Reference : Content
	{
		Label Target;
		Content Text;
	}

	class Markup : Content
	{
		MarkupKind Kind;
		Content Text;
	}

	class List : Content
	{
		list<ListItem> Items;
	}

	class ListItem
	{
		string Title;
		Content Text;
	}

	class Table : Content
	{
		int HeadColumnCount;
		int HeadRowCount;
		int ColumnCount;
		derived int RowCount;
		list<Cell> Cells;
	}

	class Cell
	{
		Content Text;
	}

	class Image : Content
	{
		string FilePath;
	}

	class PageBreak : Content
	{
	}
}
