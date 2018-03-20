namespace DevToolsX.Documents.Symbols
{
	metamodel DocumentModel(Uri="http://devtoolsx.documents.documentmodel/1.0"); 

	extern struct System.Drawing.Color Color;

	class Document : ContentContainer
	{
		[Name]
		string Title;
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

	enum VerticalAlignment
    {
        Default,
        Top,
        Center,
        Bottom
    }

    enum ListKind
    {
        None,
		Indent,
        Bullets,
        Numbers,
        RomanNumbers,
        CapitalLetters,
        SmallLetters
    }


	abstract class Content
	{
	}

	abstract class ContentContainer : Content
	{
		list<Content> Text;
	}

	class SectionTitle : Content
	{
		int Level;
		[Name]
		string Title;
		Label Label;
	}

	class Paragraph : ContentContainer
	{
		HorizontalAlignment Alignment;
	}

	class Text : Content
	{
		[Name]
		string Text;
	}

	class Label : Content
	{
		[Name]
		string Name;
	}

	class Reference : ContentContainer
	{
		string DocumentName;
		string LabelName;
		Label Target;
	}

	class Markup : ContentContainer
	{
		list<MarkupKind> Kind;
		Color ForegroundColor;
		Color BackgroundColor;
	}

	class List : Content
	{
		ListKind Kind;
		list<ListItem> Items;
	}

	class ListItem : ContentContainer
	{
		[Name]
		string Title;
	}

	class Table : Content
	{
		int HeadColumnCount;
		int HeadRowCount;
		int ColumnCount;
		derived int RowCount;
		list<TableCell> Cells;
	}

	class TableCell : ContentContainer
	{
	}

	class Image : Content
	{
		[Name]
		string FilePath;
	}

	class LineBreak : Content
	{
	}

	class PageBreak : Content
	{
	}

	class TableOfContents : Content
	{
	}
}
