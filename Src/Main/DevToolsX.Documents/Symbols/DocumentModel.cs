using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DevToolsX.Documents.Symbols
{
	using global::DevToolsX.Documents.Symbols.Internal;

	public class DocumentModelInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return DocumentModelInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaModel MetaModel;
		public static readonly global::MetaDslx.Core.ImmutableModel Model;
	
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Document;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Document_Title;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Content;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass ContentContainer;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty ContentContainer_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass SectionTitle;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty SectionTitle_Level;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty SectionTitle_Title;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty SectionTitle_Label;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Paragraph;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Paragraph_Alignment;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Text_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Label;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Label_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Reference;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Reference_DocumentName;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Reference_LabelName;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Reference_Target;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Markup;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Markup_Kind;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Markup_ForegroundColor;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Markup_BackgroundColor;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass List;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty List_Kind;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty List_Items;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass ListItem;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty ListItem_Title;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Table;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_HeadColumnCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_HeadRowCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_ColumnCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_RowCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_Cells;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass TableCell;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Image;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Image_FilePath;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass LineBreak;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass PageBreak;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass TableOfContents;
	
		static DocumentModelInstance()
		{
			DocumentModelBuilderInstance.instance.Create();
			DocumentModelBuilderInstance.instance.EvaluateLazyValues();
			MetaModel = DocumentModelBuilderInstance.instance.MetaModel.ToImmutable();
			Model = DocumentModelBuilderInstance.instance.Model.ToImmutable();
	
	
			Document = DocumentModelBuilderInstance.instance.Document.ToImmutable(Model);
			Document_Title = DocumentModelBuilderInstance.instance.Document_Title.ToImmutable(Model);
			Content = DocumentModelBuilderInstance.instance.Content.ToImmutable(Model);
			ContentContainer = DocumentModelBuilderInstance.instance.ContentContainer.ToImmutable(Model);
			ContentContainer_Text = DocumentModelBuilderInstance.instance.ContentContainer_Text.ToImmutable(Model);
			SectionTitle = DocumentModelBuilderInstance.instance.SectionTitle.ToImmutable(Model);
			SectionTitle_Level = DocumentModelBuilderInstance.instance.SectionTitle_Level.ToImmutable(Model);
			SectionTitle_Title = DocumentModelBuilderInstance.instance.SectionTitle_Title.ToImmutable(Model);
			SectionTitle_Label = DocumentModelBuilderInstance.instance.SectionTitle_Label.ToImmutable(Model);
			Paragraph = DocumentModelBuilderInstance.instance.Paragraph.ToImmutable(Model);
			Paragraph_Alignment = DocumentModelBuilderInstance.instance.Paragraph_Alignment.ToImmutable(Model);
			Text = DocumentModelBuilderInstance.instance.Text.ToImmutable(Model);
			Text_Text = DocumentModelBuilderInstance.instance.Text_Text.ToImmutable(Model);
			Label = DocumentModelBuilderInstance.instance.Label.ToImmutable(Model);
			Label_Name = DocumentModelBuilderInstance.instance.Label_Name.ToImmutable(Model);
			Reference = DocumentModelBuilderInstance.instance.Reference.ToImmutable(Model);
			Reference_DocumentName = DocumentModelBuilderInstance.instance.Reference_DocumentName.ToImmutable(Model);
			Reference_LabelName = DocumentModelBuilderInstance.instance.Reference_LabelName.ToImmutable(Model);
			Reference_Target = DocumentModelBuilderInstance.instance.Reference_Target.ToImmutable(Model);
			Markup = DocumentModelBuilderInstance.instance.Markup.ToImmutable(Model);
			Markup_Kind = DocumentModelBuilderInstance.instance.Markup_Kind.ToImmutable(Model);
			Markup_ForegroundColor = DocumentModelBuilderInstance.instance.Markup_ForegroundColor.ToImmutable(Model);
			Markup_BackgroundColor = DocumentModelBuilderInstance.instance.Markup_BackgroundColor.ToImmutable(Model);
			List = DocumentModelBuilderInstance.instance.List.ToImmutable(Model);
			List_Kind = DocumentModelBuilderInstance.instance.List_Kind.ToImmutable(Model);
			List_Items = DocumentModelBuilderInstance.instance.List_Items.ToImmutable(Model);
			ListItem = DocumentModelBuilderInstance.instance.ListItem.ToImmutable(Model);
			ListItem_Title = DocumentModelBuilderInstance.instance.ListItem_Title.ToImmutable(Model);
			Table = DocumentModelBuilderInstance.instance.Table.ToImmutable(Model);
			Table_HeadColumnCount = DocumentModelBuilderInstance.instance.Table_HeadColumnCount.ToImmutable(Model);
			Table_HeadRowCount = DocumentModelBuilderInstance.instance.Table_HeadRowCount.ToImmutable(Model);
			Table_ColumnCount = DocumentModelBuilderInstance.instance.Table_ColumnCount.ToImmutable(Model);
			Table_RowCount = DocumentModelBuilderInstance.instance.Table_RowCount.ToImmutable(Model);
			Table_Cells = DocumentModelBuilderInstance.instance.Table_Cells.ToImmutable(Model);
			TableCell = DocumentModelBuilderInstance.instance.TableCell.ToImmutable(Model);
			Image = DocumentModelBuilderInstance.instance.Image.ToImmutable(Model);
			Image_FilePath = DocumentModelBuilderInstance.instance.Image_FilePath.ToImmutable(Model);
			LineBreak = DocumentModelBuilderInstance.instance.LineBreak.ToImmutable(Model);
			PageBreak = DocumentModelBuilderInstance.instance.PageBreak.ToImmutable(Model);
			TableOfContents = DocumentModelBuilderInstance.instance.TableOfContents.ToImmutable(Model);
	
			DocumentModelInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class DocumentModelFactory : global::MetaDslx.Core.ModelFactory
	{
		public DocumentModelFactory(global::MetaDslx.Core.MutableModel model, global::MetaDslx.Core.ModelFactoryFlags flags = global::MetaDslx.Core.ModelFactoryFlags.None)
			: base(model, flags)
		{
			DocumentModelDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Core.MutableSymbol Create(string type)
		{
			switch (type)
			{
				case "Document": return this.Document();
				case "SectionTitle": return this.SectionTitle();
				case "Paragraph": return this.Paragraph();
				case "Text": return this.Text();
				case "Label": return this.Label();
				case "Reference": return this.Reference();
				case "Markup": return this.Markup();
				case "List": return this.List();
				case "ListItem": return this.ListItem();
				case "Table": return this.Table();
				case "TableCell": return this.TableCell();
				case "Image": return this.Image();
				case "LineBreak": return this.LineBreak();
				case "PageBreak": return this.PageBreak();
				case "TableOfContents": return this.TableOfContents();
				default:
					throw new global::MetaDslx.Core.ModelException(global::MetaDslx.Compiler.Diagnostics.Location.None, new global::MetaDslx.Compiler.Diagnostics.DiagnosticInfo(global::MetaDslx.Core.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of Document.
		/// </summary>
		public DocumentBuilder Document()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new DocumentId());
			return (DocumentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of SectionTitle.
		/// </summary>
		public SectionTitleBuilder SectionTitle()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new SectionTitleId());
			return (SectionTitleBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Paragraph.
		/// </summary>
		public ParagraphBuilder Paragraph()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ParagraphId());
			return (ParagraphBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Text.
		/// </summary>
		public TextBuilder Text()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new TextId());
			return (TextBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Label.
		/// </summary>
		public LabelBuilder Label()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new LabelId());
			return (LabelBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Reference.
		/// </summary>
		public ReferenceBuilder Reference()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ReferenceId());
			return (ReferenceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Markup.
		/// </summary>
		public MarkupBuilder Markup()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MarkupId());
			return (MarkupBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of List.
		/// </summary>
		public ListBuilder List()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ListId());
			return (ListBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of ListItem.
		/// </summary>
		public ListItemBuilder ListItem()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ListItemId());
			return (ListItemBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Table.
		/// </summary>
		public TableBuilder Table()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new TableId());
			return (TableBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of TableCell.
		/// </summary>
		public TableCellBuilder TableCell()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new TableCellId());
			return (TableCellBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Image.
		/// </summary>
		public ImageBuilder Image()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ImageId());
			return (ImageBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of LineBreak.
		/// </summary>
		public LineBreakBuilder LineBreak()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new LineBreakId());
			return (LineBreakBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of PageBreak.
		/// </summary>
		public PageBreakBuilder PageBreak()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new PageBreakId());
			return (PageBreakBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of TableOfContents.
		/// </summary>
		public TableOfContentsBuilder TableOfContents()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new TableOfContentsId());
			return (TableOfContentsBuilder)symbol;
		}
	}
	

	
	public enum MarkupKind
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
	
	public static class MarkupKindExtensions
	{
	}
	
	public enum HorizontalAlignment
	{
		Default,
		Justify,
		Left,
		Center,
		Right
	}
	
	public static class HorizontalAlignmentExtensions
	{
	}
	
	public enum VerticalAlignment
	{
		Default,
		Top,
		Center,
		Bottom
	}
	
	public static class VerticalAlignmentExtensions
	{
	}
	
	public enum ListKind
	{
		None,
		Indent,
		Bullets,
		Numbers,
		RomanNumbers,
		CapitalLetters,
		SmallLetters
	}
	
	public static class ListKindExtensions
	{
	}
	
	public interface Document : ContentContainer
	{
		string Title { get; }
	
	
		new DocumentBuilder ToMutable();
		new DocumentBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DocumentBuilder : ContentContainerBuilder
	{
		string Title { get; set; }
		Func<string> TitleLazy { get; set; }
	
		new Document ToImmutable();
		new Document ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Content : global::MetaDslx.Core.ImmutableSymbol
	{
	
	
		new ContentBuilder ToMutable();
		new ContentBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ContentBuilder : global::MetaDslx.Core.MutableSymbol
	{
	
		new Content ToImmutable();
		new Content ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface ContentContainer : Content
	{
		global::MetaDslx.Core.ImmutableModelList<Content> Text { get; }
	
	
		new ContentContainerBuilder ToMutable();
		new ContentContainerBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ContentContainerBuilder : ContentBuilder
	{
		global::MetaDslx.Core.MutableModelList<ContentBuilder> Text { get; }
	
		new ContentContainer ToImmutable();
		new ContentContainer ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface SectionTitle : Content
	{
		int Level { get; }
		string Title { get; }
		Label Label { get; }
	
	
		new SectionTitleBuilder ToMutable();
		new SectionTitleBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface SectionTitleBuilder : ContentBuilder
	{
		int Level { get; set; }
		Func<int> LevelLazy { get; set; }
		string Title { get; set; }
		Func<string> TitleLazy { get; set; }
		LabelBuilder Label { get; set; }
		Func<LabelBuilder> LabelLazy { get; set; }
	
		new SectionTitle ToImmutable();
		new SectionTitle ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Paragraph : ContentContainer
	{
		HorizontalAlignment Alignment { get; }
	
	
		new ParagraphBuilder ToMutable();
		new ParagraphBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ParagraphBuilder : ContentContainerBuilder
	{
		HorizontalAlignment Alignment { get; set; }
		Func<HorizontalAlignment> AlignmentLazy { get; set; }
	
		new Paragraph ToImmutable();
		new Paragraph ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Text : Content
	{
		string Text { get; }
	
	
		new TextBuilder ToMutable();
		new TextBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface TextBuilder : ContentBuilder
	{
		string Text { get; set; }
		Func<string> TextLazy { get; set; }
	
		new Text ToImmutable();
		new Text ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Label : Content
	{
		string Name { get; }
	
	
		new LabelBuilder ToMutable();
		new LabelBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface LabelBuilder : ContentBuilder
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new Label ToImmutable();
		new Label ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Reference : ContentContainer
	{
		string DocumentName { get; }
		string LabelName { get; }
		Label Target { get; }
	
	
		new ReferenceBuilder ToMutable();
		new ReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ReferenceBuilder : ContentContainerBuilder
	{
		string DocumentName { get; set; }
		Func<string> DocumentNameLazy { get; set; }
		string LabelName { get; set; }
		Func<string> LabelNameLazy { get; set; }
		LabelBuilder Target { get; set; }
		Func<LabelBuilder> TargetLazy { get; set; }
	
		new Reference ToImmutable();
		new Reference ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Markup : ContentContainer
	{
		global::MetaDslx.Core.ImmutableModelList<MarkupKind> Kind { get; }
		System.Drawing.Color ForegroundColor { get; }
		System.Drawing.Color BackgroundColor { get; }
	
	
		new MarkupBuilder ToMutable();
		new MarkupBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MarkupBuilder : ContentContainerBuilder
	{
		global::MetaDslx.Core.MutableModelList<MarkupKind> Kind { get; }
		System.Drawing.Color ForegroundColor { get; set; }
		Func<System.Drawing.Color> ForegroundColorLazy { get; set; }
		System.Drawing.Color BackgroundColor { get; set; }
		Func<System.Drawing.Color> BackgroundColorLazy { get; set; }
	
		new Markup ToImmutable();
		new Markup ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface List : Content
	{
		ListKind Kind { get; }
		global::MetaDslx.Core.ImmutableModelList<ListItem> Items { get; }
	
	
		new ListBuilder ToMutable();
		new ListBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ListBuilder : ContentBuilder
	{
		ListKind Kind { get; set; }
		Func<ListKind> KindLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<ListItemBuilder> Items { get; }
	
		new List ToImmutable();
		new List ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface ListItem : ContentContainer
	{
		string Title { get; }
	
	
		new ListItemBuilder ToMutable();
		new ListItemBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ListItemBuilder : ContentContainerBuilder
	{
		string Title { get; set; }
		Func<string> TitleLazy { get; set; }
	
		new ListItem ToImmutable();
		new ListItem ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Table : Content
	{
		int HeadColumnCount { get; }
		int HeadRowCount { get; }
		int ColumnCount { get; }
		int RowCount { get; }
		global::MetaDslx.Core.ImmutableModelList<TableCell> Cells { get; }
	
	
		new TableBuilder ToMutable();
		new TableBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface TableBuilder : ContentBuilder
	{
		int HeadColumnCount { get; set; }
		Func<int> HeadColumnCountLazy { get; set; }
		int HeadRowCount { get; set; }
		Func<int> HeadRowCountLazy { get; set; }
		int ColumnCount { get; set; }
		Func<int> ColumnCountLazy { get; set; }
		int RowCount { get; }
		Func<int> RowCountLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<TableCellBuilder> Cells { get; }
	
		new Table ToImmutable();
		new Table ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface TableCell : ContentContainer
	{
	
	
		new TableCellBuilder ToMutable();
		new TableCellBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface TableCellBuilder : ContentContainerBuilder
	{
	
		new TableCell ToImmutable();
		new TableCell ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Image : Content
	{
		string FilePath { get; }
	
	
		new ImageBuilder ToMutable();
		new ImageBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ImageBuilder : ContentBuilder
	{
		string FilePath { get; set; }
		Func<string> FilePathLazy { get; set; }
	
		new Image ToImmutable();
		new Image ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface LineBreak : Content
	{
	
	
		new LineBreakBuilder ToMutable();
		new LineBreakBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface LineBreakBuilder : ContentBuilder
	{
	
		new LineBreak ToImmutable();
		new LineBreak ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface PageBreak : Content
	{
	
	
		new PageBreakBuilder ToMutable();
		new PageBreakBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface PageBreakBuilder : ContentBuilder
	{
	
		new PageBreak ToImmutable();
		new PageBreak ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface TableOfContents : Content
	{
	
	
		new TableOfContentsBuilder ToMutable();
		new TableOfContentsBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface TableOfContentsBuilder : ContentBuilder
	{
	
		new TableOfContents ToImmutable();
		new TableOfContents ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}

	public static class DocumentModelDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty> properties;
	
		static DocumentModelDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty>();
			Document.Initialize();
			Content.Initialize();
			ContentContainer.Initialize();
			SectionTitle.Initialize();
			Paragraph.Initialize();
			Text.Initialize();
			Label.Initialize();
			Reference.Initialize();
			Markup.Initialize();
			List.Initialize();
			ListItem.Initialize();
			Table.Initialize();
			TableCell.Initialize();
			Image.Initialize();
			LineBreak.Initialize();
			PageBreak.Initialize();
			TableOfContents.Initialize();
			properties.Add(DocumentModelDescriptor.Document.TitleProperty);
			properties.Add(DocumentModelDescriptor.ContentContainer.TextProperty);
			properties.Add(DocumentModelDescriptor.SectionTitle.LevelProperty);
			properties.Add(DocumentModelDescriptor.SectionTitle.TitleProperty);
			properties.Add(DocumentModelDescriptor.SectionTitle.LabelProperty);
			properties.Add(DocumentModelDescriptor.Paragraph.AlignmentProperty);
			properties.Add(DocumentModelDescriptor.Text.TextProperty);
			properties.Add(DocumentModelDescriptor.Label.NameProperty);
			properties.Add(DocumentModelDescriptor.Reference.DocumentNameProperty);
			properties.Add(DocumentModelDescriptor.Reference.LabelNameProperty);
			properties.Add(DocumentModelDescriptor.Reference.TargetProperty);
			properties.Add(DocumentModelDescriptor.Markup.KindProperty);
			properties.Add(DocumentModelDescriptor.Markup.ForegroundColorProperty);
			properties.Add(DocumentModelDescriptor.Markup.BackgroundColorProperty);
			properties.Add(DocumentModelDescriptor.List.KindProperty);
			properties.Add(DocumentModelDescriptor.List.ItemsProperty);
			properties.Add(DocumentModelDescriptor.ListItem.TitleProperty);
			properties.Add(DocumentModelDescriptor.Table.HeadColumnCountProperty);
			properties.Add(DocumentModelDescriptor.Table.HeadRowCountProperty);
			properties.Add(DocumentModelDescriptor.Table.ColumnCountProperty);
			properties.Add(DocumentModelDescriptor.Table.RowCountProperty);
			properties.Add(DocumentModelDescriptor.Table.CellsProperty);
			properties.Add(DocumentModelDescriptor.Image.FilePathProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "http://devtoolsx.documents.documentmodel/1.0";
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Document), typeof(global::DevToolsX.Documents.Symbols.DocumentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.ContentContainer) })]
		public static class Document
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Document()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Document));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Document; }
			}
			
			[global::MetaDslx.Core.NameAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty TitleProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Document), "Title",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Document_Title);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Content), typeof(global::DevToolsX.Documents.Symbols.ContentBuilder))]
		public static class Content
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Content()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Content));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Content; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.ContentContainer), typeof(global::DevToolsX.Documents.Symbols.ContentContainerBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class ContentContainer
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static ContentContainer()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ContentContainer));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.ContentContainer; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty TextProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ContentContainer), "Text",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Content), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.Content>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ContentBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.ContentBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.ContentContainer_Text);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.SectionTitle), typeof(global::DevToolsX.Documents.Symbols.SectionTitleBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class SectionTitle
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static SectionTitle()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(SectionTitle));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.SectionTitle; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty LevelProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SectionTitle), "Level",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.SectionTitle_Level);
			
			[global::MetaDslx.Core.NameAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty TitleProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SectionTitle), "Title",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.SectionTitle_Title);
			
			public static readonly global::MetaDslx.Core.ModelProperty LabelProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SectionTitle), "Label",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Label), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.LabelBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.SectionTitle_Label);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Paragraph), typeof(global::DevToolsX.Documents.Symbols.ParagraphBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.ContentContainer) })]
		public static class Paragraph
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Paragraph()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Paragraph));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Paragraph; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty AlignmentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Paragraph), "Alignment",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.HorizontalAlignment), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.HorizontalAlignment), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Paragraph_Alignment);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Text), typeof(global::DevToolsX.Documents.Symbols.TextBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class Text
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Text()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Text));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Text; }
			}
			
			[global::MetaDslx.Core.NameAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty TextProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Text), "Text",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Text_Text);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Label), typeof(global::DevToolsX.Documents.Symbols.LabelBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class Label
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Label()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Label));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Label; }
			}
			
			[global::MetaDslx.Core.NameAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Label), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Label_Name);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Reference), typeof(global::DevToolsX.Documents.Symbols.ReferenceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.ContentContainer) })]
		public static class Reference
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Reference()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Reference));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Reference; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty DocumentNameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Reference), "DocumentName",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Reference_DocumentName);
			
			public static readonly global::MetaDslx.Core.ModelProperty LabelNameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Reference), "LabelName",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Reference_LabelName);
			
			public static readonly global::MetaDslx.Core.ModelProperty TargetProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Reference), "Target",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Label), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.LabelBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Reference_Target);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Markup), typeof(global::DevToolsX.Documents.Symbols.MarkupBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.ContentContainer) })]
		public static class Markup
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Markup()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Markup));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Markup; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty KindProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Markup), "Kind",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.MarkupKind), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.MarkupKind>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.MarkupKind), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.MarkupKind>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Markup_Kind);
			
			public static readonly global::MetaDslx.Core.ModelProperty ForegroundColorProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Markup), "ForegroundColor",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(System.Drawing.Color), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(System.Drawing.Color), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Markup_ForegroundColor);
			
			public static readonly global::MetaDslx.Core.ModelProperty BackgroundColorProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Markup), "BackgroundColor",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(System.Drawing.Color), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(System.Drawing.Color), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Markup_BackgroundColor);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.List), typeof(global::DevToolsX.Documents.Symbols.ListBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class List
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static List()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(List));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.List; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty KindProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(List), "Kind",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ListKind), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ListKind), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.List_Kind);
			
			public static readonly global::MetaDslx.Core.ModelProperty ItemsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(List), "Items",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ListItem), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.ListItem>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ListItemBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.ListItemBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.List_Items);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.ListItem), typeof(global::DevToolsX.Documents.Symbols.ListItemBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.ContentContainer) })]
		public static class ListItem
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static ListItem()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ListItem));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.ListItem; }
			}
			
			[global::MetaDslx.Core.NameAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty TitleProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ListItem), "Title",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.ListItem_Title);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Table), typeof(global::DevToolsX.Documents.Symbols.TableBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class Table
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Table()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Table));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Table; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty HeadColumnCountProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Table), "HeadColumnCount",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Table_HeadColumnCount);
			
			public static readonly global::MetaDslx.Core.ModelProperty HeadRowCountProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Table), "HeadRowCount",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Table_HeadRowCount);
			
			public static readonly global::MetaDslx.Core.ModelProperty ColumnCountProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Table), "ColumnCount",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Table_ColumnCount);
			
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty RowCountProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Table), "RowCount",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(int), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Table_RowCount);
			
			public static readonly global::MetaDslx.Core.ModelProperty CellsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Table), "Cells",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.TableCell), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.TableCell>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.TableCellBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.TableCellBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Table_Cells);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.TableCell), typeof(global::DevToolsX.Documents.Symbols.TableCellBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.ContentContainer) })]
		public static class TableCell
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static TableCell()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(TableCell));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.TableCell; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Image), typeof(global::DevToolsX.Documents.Symbols.ImageBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class Image
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Image()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Image));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Image; }
			}
			
			[global::MetaDslx.Core.NameAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty FilePathProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Image), "FilePath",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Image_FilePath);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.LineBreak), typeof(global::DevToolsX.Documents.Symbols.LineBreakBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class LineBreak
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static LineBreak()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(LineBreak));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.LineBreak; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.PageBreak), typeof(global::DevToolsX.Documents.Symbols.PageBreakBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class PageBreak
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static PageBreak()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(PageBreak));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.PageBreak; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.TableOfContents), typeof(global::DevToolsX.Documents.Symbols.TableOfContentsBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class TableOfContents
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static TableOfContents()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(TableOfContents));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.TableOfContents; }
			}
		}
	}
}

namespace DevToolsX.Documents.Symbols.Internal
{
	
	internal class DocumentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new DocumentImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new DocumentBuilderImpl(this, model, creating);
		}
	}
	
	internal class DocumentImpl : global::MetaDslx.Core.ImmutableSymbolBase, Document
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string title0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> text0;
	
		internal DocumentImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Document; }
		}
	
		public new DocumentBuilder ToMutable()
		{
			return (DocumentBuilder)base.ToMutable();
		}
	
		public new DocumentBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (DocumentBuilder)base.ToMutable(model);
		}
	
		ContentContainerBuilder ContentContainer.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentContainerBuilder ContentContainer.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Title
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.TitleProperty, ref title0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Text
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class DocumentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DocumentBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> text0;
	
		internal DocumentBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Document(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Document; }
		}
	
		public new Document ToImmutable()
		{
			return (Document)base.ToImmutable();
		}
	
		public new Document ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Document)base.ToImmutable(model);
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Title
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.TitleProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.TitleProperty, value); }
		}
		
		public Func<string> TitleLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.TitleProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Document.TitleProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Text
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class ContentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Content.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ContentImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ContentBuilderImpl(this, model, creating);
		}
	}
	
	internal class ContentImpl : global::MetaDslx.Core.ImmutableSymbolBase, Content
	{
	
		internal ContentImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Content; }
		}
	
		public new ContentBuilder ToMutable()
		{
			return (ContentBuilder)base.ToMutable();
		}
	
		public new ContentBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ContentBuilder)base.ToMutable(model);
		}
	}
	
	internal class ContentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ContentBuilder
	{
	
		internal ContentBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Content(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Content; }
		}
	
		public new Content ToImmutable()
		{
			return (Content)base.ToImmutable();
		}
	
		public new Content ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Content)base.ToImmutable(model);
		}
	}
	
	internal class ContentContainerId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ContentContainerImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ContentContainerBuilderImpl(this, model, creating);
		}
	}
	
	internal class ContentContainerImpl : global::MetaDslx.Core.ImmutableSymbolBase, ContentContainer
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> text0;
	
		internal ContentContainerImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.ContentContainer; }
		}
	
		public new ContentContainerBuilder ToMutable()
		{
			return (ContentContainerBuilder)base.ToMutable();
		}
	
		public new ContentContainerBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ContentContainerBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Text
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class ContentContainerBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ContentContainerBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> text0;
	
		internal ContentContainerBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.ContentContainer(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.ContentContainer; }
		}
	
		public new ContentContainer ToImmutable()
		{
			return (ContentContainer)base.ToImmutable();
		}
	
		public new ContentContainer ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (ContentContainer)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Text
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class SectionTitleId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new SectionTitleImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new SectionTitleBuilderImpl(this, model, creating);
		}
	}
	
	internal class SectionTitleImpl : global::MetaDslx.Core.ImmutableSymbolBase, SectionTitle
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int level0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string title0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Label label0;
	
		internal SectionTitleImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.SectionTitle; }
		}
	
		public new SectionTitleBuilder ToMutable()
		{
			return (SectionTitleBuilder)base.ToMutable();
		}
	
		public new SectionTitleBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (SectionTitleBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public int Level
		{
		    get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LevelProperty, ref level0); }
		}
	
		
		public string Title
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.TitleProperty, ref title0); }
		}
	
		
		public Label Label
		{
		    get { return this.GetReference<Label>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LabelProperty, ref label0); }
		}
	}
	
	internal class SectionTitleBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, SectionTitleBuilder
	{
	
		internal SectionTitleBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.SectionTitle(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.SectionTitle; }
		}
	
		public new SectionTitle ToImmutable()
		{
			return (SectionTitle)base.ToImmutable();
		}
	
		public new SectionTitle ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (SectionTitle)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public int Level
		{
			get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LevelProperty); }
			set { this.SetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LevelProperty, value); }
		}
		
		public Func<int> LevelLazy
		{
			get { return this.GetLazyValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LevelProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.SectionTitle.LevelProperty, value); }
		}
	
		
		public string Title
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.TitleProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.TitleProperty, value); }
		}
		
		public Func<string> TitleLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.TitleProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.SectionTitle.TitleProperty, value); }
		}
	
		
		public LabelBuilder Label
		{
			get { return this.GetReference<LabelBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LabelProperty); }
			set { this.SetReference<LabelBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LabelProperty, value); }
		}
		
		public Func<LabelBuilder> LabelLazy
		{
			get { return this.GetLazyReference<LabelBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.SectionTitle.LabelProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.SectionTitle.LabelProperty, value); }
		}
	}
	
	internal class ParagraphId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ParagraphImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ParagraphBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParagraphImpl : global::MetaDslx.Core.ImmutableSymbolBase, Paragraph
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private HorizontalAlignment alignment0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> text0;
	
		internal ParagraphImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Paragraph; }
		}
	
		public new ParagraphBuilder ToMutable()
		{
			return (ParagraphBuilder)base.ToMutable();
		}
	
		public new ParagraphBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ParagraphBuilder)base.ToMutable(model);
		}
	
		ContentContainerBuilder ContentContainer.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentContainerBuilder ContentContainer.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public HorizontalAlignment Alignment
		{
		    get { return this.GetValue<HorizontalAlignment>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.AlignmentProperty, ref alignment0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Text
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class ParagraphBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ParagraphBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> text0;
	
		internal ParagraphBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Paragraph(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Paragraph; }
		}
	
		public new Paragraph ToImmutable()
		{
			return (Paragraph)base.ToImmutable();
		}
	
		public new Paragraph ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Paragraph)base.ToImmutable(model);
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public HorizontalAlignment Alignment
		{
			get { return this.GetValue<HorizontalAlignment>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.AlignmentProperty); }
			set { this.SetValue<HorizontalAlignment>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.AlignmentProperty, value); }
		}
		
		public Func<HorizontalAlignment> AlignmentLazy
		{
			get { return this.GetLazyValue<HorizontalAlignment>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.AlignmentProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Paragraph.AlignmentProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Text
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class TextId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Text.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new TextImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new TextBuilderImpl(this, model, creating);
		}
	}
	
	internal class TextImpl : global::MetaDslx.Core.ImmutableSymbolBase, Text
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string text0;
	
		internal TextImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Text; }
		}
	
		public new TextBuilder ToMutable()
		{
			return (TextBuilder)base.ToMutable();
		}
	
		public new TextBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (TextBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Text
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Text.TextProperty, ref text0); }
		}
	}
	
	internal class TextBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TextBuilder
	{
	
		internal TextBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Text(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Text; }
		}
	
		public new Text ToImmutable()
		{
			return (Text)base.ToImmutable();
		}
	
		public new Text ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Text)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Text
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Text.TextProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Text.TextProperty, value); }
		}
		
		public Func<string> TextLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Text.TextProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Text.TextProperty, value); }
		}
	}
	
	internal class LabelId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Label.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new LabelImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new LabelBuilderImpl(this, model, creating);
		}
	}
	
	internal class LabelImpl : global::MetaDslx.Core.ImmutableSymbolBase, Label
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal LabelImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Label; }
		}
	
		public new LabelBuilder ToMutable()
		{
			return (LabelBuilder)base.ToMutable();
		}
	
		public new LabelBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (LabelBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Label.NameProperty, ref name0); }
		}
	}
	
	internal class LabelBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, LabelBuilder
	{
	
		internal LabelBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Label(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Label; }
		}
	
		public new Label ToImmutable()
		{
			return (Label)base.ToImmutable();
		}
	
		public new Label ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Label)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Label.NameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Label.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Label.NameProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Label.NameProperty, value); }
		}
	}
	
	internal class ReferenceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ReferenceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ReferenceBuilderImpl(this, model, creating);
		}
	}
	
	internal class ReferenceImpl : global::MetaDslx.Core.ImmutableSymbolBase, Reference
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string labelName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Label target0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> text0;
	
		internal ReferenceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Reference; }
		}
	
		public new ReferenceBuilder ToMutable()
		{
			return (ReferenceBuilder)base.ToMutable();
		}
	
		public new ReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ReferenceBuilder)base.ToMutable(model);
		}
	
		ContentContainerBuilder ContentContainer.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentContainerBuilder ContentContainer.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string DocumentName
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.DocumentNameProperty, ref documentName0); }
		}
	
		
		public string LabelName
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.LabelNameProperty, ref labelName0); }
		}
	
		
		public Label Target
		{
		    get { return this.GetReference<Label>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TargetProperty, ref target0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Text
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class ReferenceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ReferenceBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> text0;
	
		internal ReferenceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Reference(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Reference; }
		}
	
		public new Reference ToImmutable()
		{
			return (Reference)base.ToImmutable();
		}
	
		public new Reference ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Reference)base.ToImmutable(model);
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string DocumentName
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.DocumentNameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.DocumentNameProperty, value); }
		}
		
		public Func<string> DocumentNameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.DocumentNameProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Reference.DocumentNameProperty, value); }
		}
	
		
		public string LabelName
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.LabelNameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.LabelNameProperty, value); }
		}
		
		public Func<string> LabelNameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.LabelNameProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Reference.LabelNameProperty, value); }
		}
	
		
		public LabelBuilder Target
		{
			get { return this.GetReference<LabelBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TargetProperty); }
			set { this.SetReference<LabelBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TargetProperty, value); }
		}
		
		public Func<LabelBuilder> TargetLazy
		{
			get { return this.GetLazyReference<LabelBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TargetProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Reference.TargetProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Text
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class MarkupId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MarkupImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MarkupBuilderImpl(this, model, creating);
		}
	}
	
	internal class MarkupImpl : global::MetaDslx.Core.ImmutableSymbolBase, Markup
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MarkupKind> kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Drawing.Color foregroundColor0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Drawing.Color backgroundColor0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> text0;
	
		internal MarkupImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Markup; }
		}
	
		public new MarkupBuilder ToMutable()
		{
			return (MarkupBuilder)base.ToMutable();
		}
	
		public new MarkupBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MarkupBuilder)base.ToMutable(model);
		}
	
		ContentContainerBuilder ContentContainer.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentContainerBuilder ContentContainer.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MarkupKind> Kind
		{
		    get { return this.GetList<MarkupKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.KindProperty, ref kind0); }
		}
	
		
		public System.Drawing.Color ForegroundColor
		{
		    get { return this.GetValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.ForegroundColorProperty, ref foregroundColor0); }
		}
	
		
		public System.Drawing.Color BackgroundColor
		{
		    get { return this.GetValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.BackgroundColorProperty, ref backgroundColor0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Text
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class MarkupBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MarkupBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MarkupKind> kind0;
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> text0;
	
		internal MarkupBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Markup(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Markup; }
		}
	
		public new Markup ToImmutable()
		{
			return (Markup)base.ToImmutable();
		}
	
		public new Markup ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Markup)base.ToImmutable(model);
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MarkupKind> Kind
		{
			get { return this.GetList<MarkupKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.KindProperty, ref kind0); }
		}
	
		
		public System.Drawing.Color ForegroundColor
		{
			get { return this.GetValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.ForegroundColorProperty); }
			set { this.SetValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.ForegroundColorProperty, value); }
		}
		
		public Func<System.Drawing.Color> ForegroundColorLazy
		{
			get { return this.GetLazyValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.ForegroundColorProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Markup.ForegroundColorProperty, value); }
		}
	
		
		public System.Drawing.Color BackgroundColor
		{
			get { return this.GetValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.BackgroundColorProperty); }
			set { this.SetValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.BackgroundColorProperty, value); }
		}
		
		public Func<System.Drawing.Color> BackgroundColorLazy
		{
			get { return this.GetLazyValue<System.Drawing.Color>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.BackgroundColorProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Markup.BackgroundColorProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Text
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class ListId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.List.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ListImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ListBuilderImpl(this, model, creating);
		}
	}
	
	internal class ListImpl : global::MetaDslx.Core.ImmutableSymbolBase, List
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ListKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<ListItem> items0;
	
		internal ListImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.List; }
		}
	
		public new ListBuilder ToMutable()
		{
			return (ListBuilder)base.ToMutable();
		}
	
		public new ListBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ListBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public ListKind Kind
		{
		    get { return this.GetValue<ListKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.List.KindProperty, ref kind0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<ListItem> Items
		{
		    get { return this.GetList<ListItem>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.List.ItemsProperty, ref items0); }
		}
	}
	
	internal class ListBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ListBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ListItemBuilder> items0;
	
		internal ListBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.List(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.List; }
		}
	
		public new List ToImmutable()
		{
			return (List)base.ToImmutable();
		}
	
		public new List ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (List)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public ListKind Kind
		{
			get { return this.GetValue<ListKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.List.KindProperty); }
			set { this.SetValue<ListKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.List.KindProperty, value); }
		}
		
		public Func<ListKind> KindLazy
		{
			get { return this.GetLazyValue<ListKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.List.KindProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.List.KindProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ListItemBuilder> Items
		{
			get { return this.GetList<ListItemBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.List.ItemsProperty, ref items0); }
		}
	}
	
	internal class ListItemId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ListItemImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ListItemBuilderImpl(this, model, creating);
		}
	}
	
	internal class ListItemImpl : global::MetaDslx.Core.ImmutableSymbolBase, ListItem
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string title0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> text0;
	
		internal ListItemImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.ListItem; }
		}
	
		public new ListItemBuilder ToMutable()
		{
			return (ListItemBuilder)base.ToMutable();
		}
	
		public new ListItemBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ListItemBuilder)base.ToMutable(model);
		}
	
		ContentContainerBuilder ContentContainer.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentContainerBuilder ContentContainer.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Title
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TitleProperty, ref title0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Text
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class ListItemBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ListItemBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> text0;
	
		internal ListItemBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.ListItem(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.ListItem; }
		}
	
		public new ListItem ToImmutable()
		{
			return (ListItem)base.ToImmutable();
		}
	
		public new ListItem ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (ListItem)base.ToImmutable(model);
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Title
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TitleProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TitleProperty, value); }
		}
		
		public Func<string> TitleLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TitleProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.ListItem.TitleProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Text
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class TableId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new TableImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new TableBuilderImpl(this, model, creating);
		}
	}
	
	internal class TableImpl : global::MetaDslx.Core.ImmutableSymbolBase, Table
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int headColumnCount0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int headRowCount0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int columnCount0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int rowCount0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<TableCell> cells0;
	
		internal TableImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Table; }
		}
	
		public new TableBuilder ToMutable()
		{
			return (TableBuilder)base.ToMutable();
		}
	
		public new TableBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (TableBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public int HeadColumnCount
		{
		    get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadColumnCountProperty, ref headColumnCount0); }
		}
	
		
		public int HeadRowCount
		{
		    get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadRowCountProperty, ref headRowCount0); }
		}
	
		
		public int ColumnCount
		{
		    get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.ColumnCountProperty, ref columnCount0); }
		}
	
		
		public int RowCount
		{
		    get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.RowCountProperty, ref rowCount0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<TableCell> Cells
		{
		    get { return this.GetList<TableCell>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.CellsProperty, ref cells0); }
		}
	}
	
	internal class TableBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TableBuilder
	{
		private global::MetaDslx.Core.MutableModelList<TableCellBuilder> cells0;
	
		internal TableBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Table(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Table; }
		}
	
		public new Table ToImmutable()
		{
			return (Table)base.ToImmutable();
		}
	
		public new Table ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Table)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public int HeadColumnCount
		{
			get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadColumnCountProperty); }
			set { this.SetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadColumnCountProperty, value); }
		}
		
		public Func<int> HeadColumnCountLazy
		{
			get { return this.GetLazyValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadColumnCountProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Table.HeadColumnCountProperty, value); }
		}
	
		
		public int HeadRowCount
		{
			get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadRowCountProperty); }
			set { this.SetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadRowCountProperty, value); }
		}
		
		public Func<int> HeadRowCountLazy
		{
			get { return this.GetLazyValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.HeadRowCountProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Table.HeadRowCountProperty, value); }
		}
	
		
		public int ColumnCount
		{
			get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.ColumnCountProperty); }
			set { this.SetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.ColumnCountProperty, value); }
		}
		
		public Func<int> ColumnCountLazy
		{
			get { return this.GetLazyValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.ColumnCountProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Table.ColumnCountProperty, value); }
		}
	
		
		public int RowCount
		{
			get { return this.GetValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.RowCountProperty); }
		}
		
		public Func<int> RowCountLazy
		{
			get { return this.GetLazyValue<int>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.RowCountProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Table.RowCountProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<TableCellBuilder> Cells
		{
			get { return this.GetList<TableCellBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.CellsProperty, ref cells0); }
		}
	}
	
	internal class TableCellId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.TableCell.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new TableCellImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new TableCellBuilderImpl(this, model, creating);
		}
	}
	
	internal class TableCellImpl : global::MetaDslx.Core.ImmutableSymbolBase, TableCell
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> text0;
	
		internal TableCellImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.TableCell; }
		}
	
		public new TableCellBuilder ToMutable()
		{
			return (TableCellBuilder)base.ToMutable();
		}
	
		public new TableCellBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (TableCellBuilder)base.ToMutable(model);
		}
	
		ContentContainerBuilder ContentContainer.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentContainerBuilder ContentContainer.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Text
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class TableCellBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TableCellBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> text0;
	
		internal TableCellBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.TableCell(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.TableCell; }
		}
	
		public new TableCell ToImmutable()
		{
			return (TableCell)base.ToImmutable();
		}
	
		public new TableCell ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (TableCell)base.ToImmutable(model);
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ContentContainer ContentContainerBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Text
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentContainer.TextProperty, ref text0); }
		}
	}
	
	internal class ImageId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Image.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ImageImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ImageBuilderImpl(this, model, creating);
		}
	}
	
	internal class ImageImpl : global::MetaDslx.Core.ImmutableSymbolBase, Image
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string filePath0;
	
		internal ImageImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Image; }
		}
	
		public new ImageBuilder ToMutable()
		{
			return (ImageBuilder)base.ToMutable();
		}
	
		public new ImageBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ImageBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string FilePath
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Image.FilePathProperty, ref filePath0); }
		}
	}
	
	internal class ImageBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ImageBuilder
	{
	
		internal ImageBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Image(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Image; }
		}
	
		public new Image ToImmutable()
		{
			return (Image)base.ToImmutable();
		}
	
		public new Image ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Image)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string FilePath
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Image.FilePathProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Image.FilePathProperty, value); }
		}
		
		public Func<string> FilePathLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Image.FilePathProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Image.FilePathProperty, value); }
		}
	}
	
	internal class LineBreakId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.LineBreak.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new LineBreakImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new LineBreakBuilderImpl(this, model, creating);
		}
	}
	
	internal class LineBreakImpl : global::MetaDslx.Core.ImmutableSymbolBase, LineBreak
	{
	
		internal LineBreakImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.LineBreak; }
		}
	
		public new LineBreakBuilder ToMutable()
		{
			return (LineBreakBuilder)base.ToMutable();
		}
	
		public new LineBreakBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (LineBreakBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	}
	
	internal class LineBreakBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, LineBreakBuilder
	{
	
		internal LineBreakBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.LineBreak(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.LineBreak; }
		}
	
		public new LineBreak ToImmutable()
		{
			return (LineBreak)base.ToImmutable();
		}
	
		public new LineBreak ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (LineBreak)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	}
	
	internal class PageBreakId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.PageBreak.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new PageBreakImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new PageBreakBuilderImpl(this, model, creating);
		}
	}
	
	internal class PageBreakImpl : global::MetaDslx.Core.ImmutableSymbolBase, PageBreak
	{
	
		internal PageBreakImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.PageBreak; }
		}
	
		public new PageBreakBuilder ToMutable()
		{
			return (PageBreakBuilder)base.ToMutable();
		}
	
		public new PageBreakBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (PageBreakBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	}
	
	internal class PageBreakBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, PageBreakBuilder
	{
	
		internal PageBreakBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.PageBreak(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.PageBreak; }
		}
	
		public new PageBreak ToImmutable()
		{
			return (PageBreak)base.ToImmutable();
		}
	
		public new PageBreak ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (PageBreak)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	}
	
	internal class TableOfContentsId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.TableOfContents.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new TableOfContentsImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new TableOfContentsBuilderImpl(this, model, creating);
		}
	}
	
	internal class TableOfContentsImpl : global::MetaDslx.Core.ImmutableSymbolBase, TableOfContents
	{
	
		internal TableOfContentsImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.TableOfContents; }
		}
	
		public new TableOfContentsBuilder ToMutable()
		{
			return (TableOfContentsBuilder)base.ToMutable();
		}
	
		public new TableOfContentsBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (TableOfContentsBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	}
	
	internal class TableOfContentsBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TableOfContentsBuilder
	{
	
		internal TableOfContentsBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.TableOfContents(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.TableOfContents; }
		}
	
		public new TableOfContents ToImmutable()
		{
			return (TableOfContents)base.ToImmutable();
		}
	
		public new TableOfContents ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (TableOfContents)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	}

	internal class DocumentModelBuilderInstance
	{
		internal static DocumentModelBuilderInstance instance = new DocumentModelBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder MetaModel;
		internal global::MetaDslx.Core.MutableModel Model;
		internal global::MetaDslx.Core.MutableModelGroup ModelGroup;
	
	
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder __tmp4;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaExternalTypeBuilder Color;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Document;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Document_Title;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp35;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder MarkupKind;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp10;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp11;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp12;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp13;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder HorizontalAlignment;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp14;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp15;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp16;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp17;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp18;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder VerticalAlignment;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp19;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp20;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp21;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp22;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder ListKind;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp24;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp25;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp26;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp27;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp28;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp29;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Content;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ContentContainer;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder ContentContainer_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder SectionTitle;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SectionTitle_Level;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SectionTitle_Title;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp30;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SectionTitle_Label;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Paragraph;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Paragraph_Alignment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Text_Text;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp36;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Label;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Label_Name;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp34;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Reference;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Reference_DocumentName;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Reference_LabelName;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Reference_Target;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Markup;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Markup_Kind;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Markup_ForegroundColor;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Markup_BackgroundColor;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder List;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder List_Kind;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder List_Items;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ListItem;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder ListItem_Title;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp32;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Table;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_HeadColumnCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_HeadRowCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_ColumnCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_RowCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_Cells;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder TableCell;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Image;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Image_FilePath;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp37;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder LineBreak;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder PageBreak;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder TableOfContents;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp31;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp33;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp38;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp39;
	
		internal DocumentModelBuilderInstance()
		{
			this.ModelGroup = new global::MetaDslx.Core.MutableModelGroup();
			this.ModelGroup.AddReference(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Model.ToMutable(true));
			this.Model = this.ModelGroup.CreateModel("DocumentModel");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			DocumentModelImplementationProvider.Implementation.DocumentModelBuilderInstance(this);
			this.CreateSymbols();
			lock (this)
			{
				this.created = true;
			}
		}
	
		internal void EvaluateLazyValues()
		{
			if (!this.created) return;
			this.Model.EvaluateLazyValues();
		}
	
		private void CreateSymbols()
		{
			global::MetaDslx.Languages.Meta.Symbols.MetaFactory factory = new global::MetaDslx.Languages.Meta.Symbols.MetaFactory(this.Model, global::MetaDslx.Core.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaModel();
			MetaModel = __tmp4;
			Color = factory.MetaExternalType();
			Document = factory.MetaClass();
			Document_Title = factory.MetaProperty();
			__tmp35 = factory.MetaAnnotation();
			MarkupKind = factory.MetaEnum();
			__tmp5 = factory.MetaEnumLiteral();
			__tmp6 = factory.MetaEnumLiteral();
			__tmp7 = factory.MetaEnumLiteral();
			__tmp8 = factory.MetaEnumLiteral();
			__tmp9 = factory.MetaEnumLiteral();
			__tmp10 = factory.MetaEnumLiteral();
			__tmp11 = factory.MetaEnumLiteral();
			__tmp12 = factory.MetaEnumLiteral();
			__tmp13 = factory.MetaEnumLiteral();
			HorizontalAlignment = factory.MetaEnum();
			__tmp14 = factory.MetaEnumLiteral();
			__tmp15 = factory.MetaEnumLiteral();
			__tmp16 = factory.MetaEnumLiteral();
			__tmp17 = factory.MetaEnumLiteral();
			__tmp18 = factory.MetaEnumLiteral();
			VerticalAlignment = factory.MetaEnum();
			__tmp19 = factory.MetaEnumLiteral();
			__tmp20 = factory.MetaEnumLiteral();
			__tmp21 = factory.MetaEnumLiteral();
			__tmp22 = factory.MetaEnumLiteral();
			ListKind = factory.MetaEnum();
			__tmp23 = factory.MetaEnumLiteral();
			__tmp24 = factory.MetaEnumLiteral();
			__tmp25 = factory.MetaEnumLiteral();
			__tmp26 = factory.MetaEnumLiteral();
			__tmp27 = factory.MetaEnumLiteral();
			__tmp28 = factory.MetaEnumLiteral();
			__tmp29 = factory.MetaEnumLiteral();
			Content = factory.MetaClass();
			ContentContainer = factory.MetaClass();
			ContentContainer_Text = factory.MetaProperty();
			SectionTitle = factory.MetaClass();
			SectionTitle_Level = factory.MetaProperty();
			SectionTitle_Title = factory.MetaProperty();
			__tmp30 = factory.MetaAnnotation();
			SectionTitle_Label = factory.MetaProperty();
			Paragraph = factory.MetaClass();
			Paragraph_Alignment = factory.MetaProperty();
			Text = factory.MetaClass();
			Text_Text = factory.MetaProperty();
			__tmp36 = factory.MetaAnnotation();
			Label = factory.MetaClass();
			Label_Name = factory.MetaProperty();
			__tmp34 = factory.MetaAnnotation();
			Reference = factory.MetaClass();
			Reference_DocumentName = factory.MetaProperty();
			Reference_LabelName = factory.MetaProperty();
			Reference_Target = factory.MetaProperty();
			Markup = factory.MetaClass();
			Markup_Kind = factory.MetaProperty();
			Markup_ForegroundColor = factory.MetaProperty();
			Markup_BackgroundColor = factory.MetaProperty();
			List = factory.MetaClass();
			List_Kind = factory.MetaProperty();
			List_Items = factory.MetaProperty();
			ListItem = factory.MetaClass();
			ListItem_Title = factory.MetaProperty();
			__tmp32 = factory.MetaAnnotation();
			Table = factory.MetaClass();
			Table_HeadColumnCount = factory.MetaProperty();
			Table_HeadRowCount = factory.MetaProperty();
			Table_ColumnCount = factory.MetaProperty();
			Table_RowCount = factory.MetaProperty();
			Table_Cells = factory.MetaProperty();
			TableCell = factory.MetaClass();
			Image = factory.MetaClass();
			Image_FilePath = factory.MetaProperty();
			__tmp37 = factory.MetaAnnotation();
			LineBreak = factory.MetaClass();
			PageBreak = factory.MetaClass();
			TableOfContents = factory.MetaClass();
			__tmp31 = factory.MetaCollectionType();
			__tmp33 = factory.MetaCollectionType();
			__tmp38 = factory.MetaCollectionType();
			__tmp39 = factory.MetaCollectionType();
	
			// __tmp1.MetaModel = null;
			// __tmp1.Namespace = null;
			__tmp1.Documentation = null;
			__tmp1.Name = "DevToolsX";
			// __tmp1.MetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			// __tmp2.MetaModel = null;
			__tmp2.NamespaceLazy = () => __tmp1;
			__tmp2.Documentation = null;
			__tmp2.Name = "Documents";
			// __tmp2.MetaModel = null;
			__tmp2.Declarations.AddLazy(() => __tmp3);
			// __tmp3.MetaModel = null;
			__tmp3.NamespaceLazy = () => __tmp2;
			__tmp3.Documentation = null;
			__tmp3.Name = "Symbols";
			__tmp3.MetaModelLazy = () => __tmp4;
			__tmp3.Declarations.AddLazy(() => Color);
			__tmp3.Declarations.AddLazy(() => Document);
			__tmp3.Declarations.AddLazy(() => MarkupKind);
			__tmp3.Declarations.AddLazy(() => HorizontalAlignment);
			__tmp3.Declarations.AddLazy(() => VerticalAlignment);
			__tmp3.Declarations.AddLazy(() => ListKind);
			__tmp3.Declarations.AddLazy(() => Content);
			__tmp3.Declarations.AddLazy(() => ContentContainer);
			__tmp3.Declarations.AddLazy(() => SectionTitle);
			__tmp3.Declarations.AddLazy(() => Paragraph);
			__tmp3.Declarations.AddLazy(() => Text);
			__tmp3.Declarations.AddLazy(() => Label);
			__tmp3.Declarations.AddLazy(() => Reference);
			__tmp3.Declarations.AddLazy(() => Markup);
			__tmp3.Declarations.AddLazy(() => List);
			__tmp3.Declarations.AddLazy(() => ListItem);
			__tmp3.Declarations.AddLazy(() => Table);
			__tmp3.Declarations.AddLazy(() => TableCell);
			__tmp3.Declarations.AddLazy(() => Image);
			__tmp3.Declarations.AddLazy(() => LineBreak);
			__tmp3.Declarations.AddLazy(() => PageBreak);
			__tmp3.Declarations.AddLazy(() => TableOfContents);
			__tmp4.Name = "DocumentModel";
			__tmp4.Documentation = null;
			__tmp4.Uri = "http://devtoolsx.documents.documentmodel/1.0";
			__tmp4.NamespaceLazy = () => __tmp3;
			Color.Name = "Color";
			Color.Documentation = null;
			Color.NamespaceLazy = () => __tmp3;
			Color.MetaModelLazy = () => __tmp4;
			Color.ExternalName = "System.Drawing.Color";
			Color.IsValueType = true;
			Document.MetaModelLazy = () => __tmp4;
			Document.NamespaceLazy = () => __tmp3;
			Document.Documentation = null;
			Document.Name = "Document";
			// Document.IsAbstract = null;
			Document.SuperClasses.AddLazy(() => ContentContainer);
			Document.Properties.AddLazy(() => Document_Title);
			Document_Title.Annotations.AddLazy(() => __tmp35);
			Document_Title.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Document_Title.Name = "Title";
			Document_Title.Documentation = null;
			// Document_Title.Kind = null;
			Document_Title.ClassLazy = () => Document;
			__tmp35.Name = "Name";
			__tmp35.Documentation = null;
			MarkupKind.MetaModelLazy = () => __tmp4;
			MarkupKind.NamespaceLazy = () => __tmp3;
			MarkupKind.Documentation = null;
			MarkupKind.Name = "MarkupKind";
			MarkupKind.EnumLiterals.AddLazy(() => __tmp5);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp6);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp7);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp8);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp9);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp10);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp11);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp12);
			MarkupKind.EnumLiterals.AddLazy(() => __tmp13);
			__tmp5.TypeLazy = () => MarkupKind;
			__tmp5.Name = "None";
			__tmp5.Documentation = null;
			__tmp5.EnumLazy = () => MarkupKind;
			__tmp6.TypeLazy = () => MarkupKind;
			__tmp6.Name = "Bold";
			__tmp6.Documentation = null;
			__tmp6.EnumLazy = () => MarkupKind;
			__tmp7.TypeLazy = () => MarkupKind;
			__tmp7.Name = "Italic";
			__tmp7.Documentation = null;
			__tmp7.EnumLazy = () => MarkupKind;
			__tmp8.TypeLazy = () => MarkupKind;
			__tmp8.Name = "Underline";
			__tmp8.Documentation = null;
			__tmp8.EnumLazy = () => MarkupKind;
			__tmp9.TypeLazy = () => MarkupKind;
			__tmp9.Name = "Code";
			__tmp9.Documentation = null;
			__tmp9.EnumLazy = () => MarkupKind;
			__tmp10.TypeLazy = () => MarkupKind;
			__tmp10.Name = "CodeInline";
			__tmp10.Documentation = null;
			__tmp10.EnumLazy = () => MarkupKind;
			__tmp11.TypeLazy = () => MarkupKind;
			__tmp11.Name = "SubScript";
			__tmp11.Documentation = null;
			__tmp11.EnumLazy = () => MarkupKind;
			__tmp12.TypeLazy = () => MarkupKind;
			__tmp12.Name = "SuperScript";
			__tmp12.Documentation = null;
			__tmp12.EnumLazy = () => MarkupKind;
			__tmp13.TypeLazy = () => MarkupKind;
			__tmp13.Name = "Strikethrough";
			__tmp13.Documentation = null;
			__tmp13.EnumLazy = () => MarkupKind;
			HorizontalAlignment.MetaModelLazy = () => __tmp4;
			HorizontalAlignment.NamespaceLazy = () => __tmp3;
			HorizontalAlignment.Documentation = null;
			HorizontalAlignment.Name = "HorizontalAlignment";
			HorizontalAlignment.EnumLiterals.AddLazy(() => __tmp14);
			HorizontalAlignment.EnumLiterals.AddLazy(() => __tmp15);
			HorizontalAlignment.EnumLiterals.AddLazy(() => __tmp16);
			HorizontalAlignment.EnumLiterals.AddLazy(() => __tmp17);
			HorizontalAlignment.EnumLiterals.AddLazy(() => __tmp18);
			__tmp14.TypeLazy = () => HorizontalAlignment;
			__tmp14.Name = "Default";
			__tmp14.Documentation = null;
			__tmp14.EnumLazy = () => HorizontalAlignment;
			__tmp15.TypeLazy = () => HorizontalAlignment;
			__tmp15.Name = "Justify";
			__tmp15.Documentation = null;
			__tmp15.EnumLazy = () => HorizontalAlignment;
			__tmp16.TypeLazy = () => HorizontalAlignment;
			__tmp16.Name = "Left";
			__tmp16.Documentation = null;
			__tmp16.EnumLazy = () => HorizontalAlignment;
			__tmp17.TypeLazy = () => HorizontalAlignment;
			__tmp17.Name = "Center";
			__tmp17.Documentation = null;
			__tmp17.EnumLazy = () => HorizontalAlignment;
			__tmp18.TypeLazy = () => HorizontalAlignment;
			__tmp18.Name = "Right";
			__tmp18.Documentation = null;
			__tmp18.EnumLazy = () => HorizontalAlignment;
			VerticalAlignment.MetaModelLazy = () => __tmp4;
			VerticalAlignment.NamespaceLazy = () => __tmp3;
			VerticalAlignment.Documentation = null;
			VerticalAlignment.Name = "VerticalAlignment";
			VerticalAlignment.EnumLiterals.AddLazy(() => __tmp19);
			VerticalAlignment.EnumLiterals.AddLazy(() => __tmp20);
			VerticalAlignment.EnumLiterals.AddLazy(() => __tmp21);
			VerticalAlignment.EnumLiterals.AddLazy(() => __tmp22);
			__tmp19.TypeLazy = () => VerticalAlignment;
			__tmp19.Name = "Default";
			__tmp19.Documentation = null;
			__tmp19.EnumLazy = () => VerticalAlignment;
			__tmp20.TypeLazy = () => VerticalAlignment;
			__tmp20.Name = "Top";
			__tmp20.Documentation = null;
			__tmp20.EnumLazy = () => VerticalAlignment;
			__tmp21.TypeLazy = () => VerticalAlignment;
			__tmp21.Name = "Center";
			__tmp21.Documentation = null;
			__tmp21.EnumLazy = () => VerticalAlignment;
			__tmp22.TypeLazy = () => VerticalAlignment;
			__tmp22.Name = "Bottom";
			__tmp22.Documentation = null;
			__tmp22.EnumLazy = () => VerticalAlignment;
			ListKind.MetaModelLazy = () => __tmp4;
			ListKind.NamespaceLazy = () => __tmp3;
			ListKind.Documentation = null;
			ListKind.Name = "ListKind";
			ListKind.EnumLiterals.AddLazy(() => __tmp23);
			ListKind.EnumLiterals.AddLazy(() => __tmp24);
			ListKind.EnumLiterals.AddLazy(() => __tmp25);
			ListKind.EnumLiterals.AddLazy(() => __tmp26);
			ListKind.EnumLiterals.AddLazy(() => __tmp27);
			ListKind.EnumLiterals.AddLazy(() => __tmp28);
			ListKind.EnumLiterals.AddLazy(() => __tmp29);
			__tmp23.TypeLazy = () => ListKind;
			__tmp23.Name = "None";
			__tmp23.Documentation = null;
			__tmp23.EnumLazy = () => ListKind;
			__tmp24.TypeLazy = () => ListKind;
			__tmp24.Name = "Indent";
			__tmp24.Documentation = null;
			__tmp24.EnumLazy = () => ListKind;
			__tmp25.TypeLazy = () => ListKind;
			__tmp25.Name = "Bullets";
			__tmp25.Documentation = null;
			__tmp25.EnumLazy = () => ListKind;
			__tmp26.TypeLazy = () => ListKind;
			__tmp26.Name = "Numbers";
			__tmp26.Documentation = null;
			__tmp26.EnumLazy = () => ListKind;
			__tmp27.TypeLazy = () => ListKind;
			__tmp27.Name = "RomanNumbers";
			__tmp27.Documentation = null;
			__tmp27.EnumLazy = () => ListKind;
			__tmp28.TypeLazy = () => ListKind;
			__tmp28.Name = "CapitalLetters";
			__tmp28.Documentation = null;
			__tmp28.EnumLazy = () => ListKind;
			__tmp29.TypeLazy = () => ListKind;
			__tmp29.Name = "SmallLetters";
			__tmp29.Documentation = null;
			__tmp29.EnumLazy = () => ListKind;
			Content.MetaModelLazy = () => __tmp4;
			Content.NamespaceLazy = () => __tmp3;
			Content.Documentation = null;
			Content.Name = "Content";
			Content.IsAbstract = true;
			ContentContainer.MetaModelLazy = () => __tmp4;
			ContentContainer.NamespaceLazy = () => __tmp3;
			ContentContainer.Documentation = null;
			ContentContainer.Name = "ContentContainer";
			ContentContainer.IsAbstract = true;
			ContentContainer.SuperClasses.AddLazy(() => Content);
			ContentContainer.Properties.AddLazy(() => ContentContainer_Text);
			ContentContainer_Text.TypeLazy = () => __tmp33;
			ContentContainer_Text.Name = "Text";
			ContentContainer_Text.Documentation = null;
			// ContentContainer_Text.Kind = null;
			ContentContainer_Text.ClassLazy = () => ContentContainer;
			SectionTitle.MetaModelLazy = () => __tmp4;
			SectionTitle.NamespaceLazy = () => __tmp3;
			SectionTitle.Documentation = null;
			SectionTitle.Name = "SectionTitle";
			// SectionTitle.IsAbstract = null;
			SectionTitle.SuperClasses.AddLazy(() => Content);
			SectionTitle.Properties.AddLazy(() => SectionTitle_Level);
			SectionTitle.Properties.AddLazy(() => SectionTitle_Title);
			SectionTitle.Properties.AddLazy(() => SectionTitle_Label);
			SectionTitle_Level.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Int.ToMutable();
			SectionTitle_Level.Name = "Level";
			SectionTitle_Level.Documentation = null;
			// SectionTitle_Level.Kind = null;
			SectionTitle_Level.ClassLazy = () => SectionTitle;
			SectionTitle_Title.Annotations.AddLazy(() => __tmp30);
			SectionTitle_Title.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			SectionTitle_Title.Name = "Title";
			SectionTitle_Title.Documentation = null;
			// SectionTitle_Title.Kind = null;
			SectionTitle_Title.ClassLazy = () => SectionTitle;
			__tmp30.Name = "Name";
			__tmp30.Documentation = null;
			SectionTitle_Label.TypeLazy = () => Label;
			SectionTitle_Label.Name = "Label";
			SectionTitle_Label.Documentation = null;
			// SectionTitle_Label.Kind = null;
			SectionTitle_Label.ClassLazy = () => SectionTitle;
			Paragraph.MetaModelLazy = () => __tmp4;
			Paragraph.NamespaceLazy = () => __tmp3;
			Paragraph.Documentation = null;
			Paragraph.Name = "Paragraph";
			// Paragraph.IsAbstract = null;
			Paragraph.SuperClasses.AddLazy(() => ContentContainer);
			Paragraph.Properties.AddLazy(() => Paragraph_Alignment);
			Paragraph_Alignment.TypeLazy = () => HorizontalAlignment;
			Paragraph_Alignment.Name = "Alignment";
			Paragraph_Alignment.Documentation = null;
			// Paragraph_Alignment.Kind = null;
			Paragraph_Alignment.ClassLazy = () => Paragraph;
			Text.MetaModelLazy = () => __tmp4;
			Text.NamespaceLazy = () => __tmp3;
			Text.Documentation = null;
			Text.Name = "Text";
			// Text.IsAbstract = null;
			Text.SuperClasses.AddLazy(() => Content);
			Text.Properties.AddLazy(() => Text_Text);
			Text_Text.Annotations.AddLazy(() => __tmp36);
			Text_Text.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Text_Text.Name = "Text";
			Text_Text.Documentation = null;
			// Text_Text.Kind = null;
			Text_Text.ClassLazy = () => Text;
			__tmp36.Name = "Name";
			__tmp36.Documentation = null;
			Label.MetaModelLazy = () => __tmp4;
			Label.NamespaceLazy = () => __tmp3;
			Label.Documentation = null;
			Label.Name = "Label";
			// Label.IsAbstract = null;
			Label.SuperClasses.AddLazy(() => Content);
			Label.Properties.AddLazy(() => Label_Name);
			Label_Name.Annotations.AddLazy(() => __tmp34);
			Label_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Label_Name.Name = "Name";
			Label_Name.Documentation = null;
			// Label_Name.Kind = null;
			Label_Name.ClassLazy = () => Label;
			__tmp34.Name = "Name";
			__tmp34.Documentation = null;
			Reference.MetaModelLazy = () => __tmp4;
			Reference.NamespaceLazy = () => __tmp3;
			Reference.Documentation = null;
			Reference.Name = "Reference";
			// Reference.IsAbstract = null;
			Reference.SuperClasses.AddLazy(() => ContentContainer);
			Reference.Properties.AddLazy(() => Reference_DocumentName);
			Reference.Properties.AddLazy(() => Reference_LabelName);
			Reference.Properties.AddLazy(() => Reference_Target);
			Reference_DocumentName.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Reference_DocumentName.Name = "DocumentName";
			Reference_DocumentName.Documentation = null;
			// Reference_DocumentName.Kind = null;
			Reference_DocumentName.ClassLazy = () => Reference;
			Reference_LabelName.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Reference_LabelName.Name = "LabelName";
			Reference_LabelName.Documentation = null;
			// Reference_LabelName.Kind = null;
			Reference_LabelName.ClassLazy = () => Reference;
			Reference_Target.TypeLazy = () => Label;
			Reference_Target.Name = "Target";
			Reference_Target.Documentation = null;
			// Reference_Target.Kind = null;
			Reference_Target.ClassLazy = () => Reference;
			Markup.MetaModelLazy = () => __tmp4;
			Markup.NamespaceLazy = () => __tmp3;
			Markup.Documentation = null;
			Markup.Name = "Markup";
			// Markup.IsAbstract = null;
			Markup.SuperClasses.AddLazy(() => ContentContainer);
			Markup.Properties.AddLazy(() => Markup_Kind);
			Markup.Properties.AddLazy(() => Markup_ForegroundColor);
			Markup.Properties.AddLazy(() => Markup_BackgroundColor);
			Markup_Kind.TypeLazy = () => __tmp31;
			Markup_Kind.Name = "Kind";
			Markup_Kind.Documentation = null;
			// Markup_Kind.Kind = null;
			Markup_Kind.ClassLazy = () => Markup;
			Markup_ForegroundColor.TypeLazy = () => Color;
			Markup_ForegroundColor.Name = "ForegroundColor";
			Markup_ForegroundColor.Documentation = null;
			// Markup_ForegroundColor.Kind = null;
			Markup_ForegroundColor.ClassLazy = () => Markup;
			Markup_BackgroundColor.TypeLazy = () => Color;
			Markup_BackgroundColor.Name = "BackgroundColor";
			Markup_BackgroundColor.Documentation = null;
			// Markup_BackgroundColor.Kind = null;
			Markup_BackgroundColor.ClassLazy = () => Markup;
			List.MetaModelLazy = () => __tmp4;
			List.NamespaceLazy = () => __tmp3;
			List.Documentation = null;
			List.Name = "List";
			// List.IsAbstract = null;
			List.SuperClasses.AddLazy(() => Content);
			List.Properties.AddLazy(() => List_Kind);
			List.Properties.AddLazy(() => List_Items);
			List_Kind.TypeLazy = () => ListKind;
			List_Kind.Name = "Kind";
			List_Kind.Documentation = null;
			// List_Kind.Kind = null;
			List_Kind.ClassLazy = () => List;
			List_Items.TypeLazy = () => __tmp39;
			List_Items.Name = "Items";
			List_Items.Documentation = null;
			// List_Items.Kind = null;
			List_Items.ClassLazy = () => List;
			ListItem.MetaModelLazy = () => __tmp4;
			ListItem.NamespaceLazy = () => __tmp3;
			ListItem.Documentation = null;
			ListItem.Name = "ListItem";
			// ListItem.IsAbstract = null;
			ListItem.SuperClasses.AddLazy(() => ContentContainer);
			ListItem.Properties.AddLazy(() => ListItem_Title);
			ListItem_Title.Annotations.AddLazy(() => __tmp32);
			ListItem_Title.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			ListItem_Title.Name = "Title";
			ListItem_Title.Documentation = null;
			// ListItem_Title.Kind = null;
			ListItem_Title.ClassLazy = () => ListItem;
			__tmp32.Name = "Name";
			__tmp32.Documentation = null;
			Table.MetaModelLazy = () => __tmp4;
			Table.NamespaceLazy = () => __tmp3;
			Table.Documentation = null;
			Table.Name = "Table";
			// Table.IsAbstract = null;
			Table.SuperClasses.AddLazy(() => Content);
			Table.Properties.AddLazy(() => Table_HeadColumnCount);
			Table.Properties.AddLazy(() => Table_HeadRowCount);
			Table.Properties.AddLazy(() => Table_ColumnCount);
			Table.Properties.AddLazy(() => Table_RowCount);
			Table.Properties.AddLazy(() => Table_Cells);
			Table_HeadColumnCount.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Int.ToMutable();
			Table_HeadColumnCount.Name = "HeadColumnCount";
			Table_HeadColumnCount.Documentation = null;
			// Table_HeadColumnCount.Kind = null;
			Table_HeadColumnCount.ClassLazy = () => Table;
			Table_HeadRowCount.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Int.ToMutable();
			Table_HeadRowCount.Name = "HeadRowCount";
			Table_HeadRowCount.Documentation = null;
			// Table_HeadRowCount.Kind = null;
			Table_HeadRowCount.ClassLazy = () => Table;
			Table_ColumnCount.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Int.ToMutable();
			Table_ColumnCount.Name = "ColumnCount";
			Table_ColumnCount.Documentation = null;
			// Table_ColumnCount.Kind = null;
			Table_ColumnCount.ClassLazy = () => Table;
			Table_RowCount.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Int.ToMutable();
			Table_RowCount.Name = "RowCount";
			Table_RowCount.Documentation = null;
			Table_RowCount.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Derived;
			Table_RowCount.ClassLazy = () => Table;
			Table_Cells.TypeLazy = () => __tmp38;
			Table_Cells.Name = "Cells";
			Table_Cells.Documentation = null;
			// Table_Cells.Kind = null;
			Table_Cells.ClassLazy = () => Table;
			TableCell.MetaModelLazy = () => __tmp4;
			TableCell.NamespaceLazy = () => __tmp3;
			TableCell.Documentation = null;
			TableCell.Name = "TableCell";
			// TableCell.IsAbstract = null;
			TableCell.SuperClasses.AddLazy(() => ContentContainer);
			Image.MetaModelLazy = () => __tmp4;
			Image.NamespaceLazy = () => __tmp3;
			Image.Documentation = null;
			Image.Name = "Image";
			// Image.IsAbstract = null;
			Image.SuperClasses.AddLazy(() => Content);
			Image.Properties.AddLazy(() => Image_FilePath);
			Image_FilePath.Annotations.AddLazy(() => __tmp37);
			Image_FilePath.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Image_FilePath.Name = "FilePath";
			Image_FilePath.Documentation = null;
			// Image_FilePath.Kind = null;
			Image_FilePath.ClassLazy = () => Image;
			__tmp37.Name = "Name";
			__tmp37.Documentation = null;
			LineBreak.MetaModelLazy = () => __tmp4;
			LineBreak.NamespaceLazy = () => __tmp3;
			LineBreak.Documentation = null;
			LineBreak.Name = "LineBreak";
			// LineBreak.IsAbstract = null;
			LineBreak.SuperClasses.AddLazy(() => Content);
			PageBreak.MetaModelLazy = () => __tmp4;
			PageBreak.NamespaceLazy = () => __tmp3;
			PageBreak.Documentation = null;
			PageBreak.Name = "PageBreak";
			// PageBreak.IsAbstract = null;
			PageBreak.SuperClasses.AddLazy(() => Content);
			TableOfContents.MetaModelLazy = () => __tmp4;
			TableOfContents.NamespaceLazy = () => __tmp3;
			TableOfContents.Documentation = null;
			TableOfContents.Name = "TableOfContents";
			// TableOfContents.IsAbstract = null;
			TableOfContents.SuperClasses.AddLazy(() => Content);
			__tmp31.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp31.InnerTypeLazy = () => MarkupKind;
			__tmp33.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp33.InnerTypeLazy = () => Content;
			__tmp38.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp38.InnerTypeLazy = () => TableCell;
			__tmp39.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp39.InnerTypeLazy = () => ListItem;
	
			foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::DevToolsX.Documents.Symbols.Internal.DocumentModelImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class DocumentModelImplementationBase
	{
		/// <summary>
		/// Implements the constructor: DocumentModelBuilderInstance()
		/// </summary>
		internal virtual void DocumentModelBuilderInstance(DocumentModelBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: Document()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ContentContainer</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>ContentContainer</li>
		///     <li>Content</li>
		/// </ul>
		public virtual void Document(DocumentBuilder _this)
		{
			this.CallDocumentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Document
		/// </summary>
		protected virtual void CallDocumentSuperConstructors(DocumentBuilder _this)
		{
			this.ContentContainer(_this);
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Content()
		/// </summary>
		public virtual void Content(ContentBuilder _this)
		{
			this.CallContentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Content
		/// </summary>
		protected virtual void CallContentSuperConstructors(ContentBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: ContentContainer()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void ContentContainer(ContentContainerBuilder _this)
		{
			this.CallContentContainerSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ContentContainer
		/// </summary>
		protected virtual void CallContentContainerSuperConstructors(ContentContainerBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: SectionTitle()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void SectionTitle(SectionTitleBuilder _this)
		{
			this.CallSectionTitleSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of SectionTitle
		/// </summary>
		protected virtual void CallSectionTitleSuperConstructors(SectionTitleBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Paragraph()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ContentContainer</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>ContentContainer</li>
		///     <li>Content</li>
		/// </ul>
		public virtual void Paragraph(ParagraphBuilder _this)
		{
			this.CallParagraphSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Paragraph
		/// </summary>
		protected virtual void CallParagraphSuperConstructors(ParagraphBuilder _this)
		{
			this.ContentContainer(_this);
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Text()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void Text(TextBuilder _this)
		{
			this.CallTextSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Text
		/// </summary>
		protected virtual void CallTextSuperConstructors(TextBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Label()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void Label(LabelBuilder _this)
		{
			this.CallLabelSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Label
		/// </summary>
		protected virtual void CallLabelSuperConstructors(LabelBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Reference()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ContentContainer</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>ContentContainer</li>
		///     <li>Content</li>
		/// </ul>
		public virtual void Reference(ReferenceBuilder _this)
		{
			this.CallReferenceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Reference
		/// </summary>
		protected virtual void CallReferenceSuperConstructors(ReferenceBuilder _this)
		{
			this.ContentContainer(_this);
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Markup()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ContentContainer</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>ContentContainer</li>
		///     <li>Content</li>
		/// </ul>
		public virtual void Markup(MarkupBuilder _this)
		{
			this.CallMarkupSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Markup
		/// </summary>
		protected virtual void CallMarkupSuperConstructors(MarkupBuilder _this)
		{
			this.ContentContainer(_this);
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: List()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void List(ListBuilder _this)
		{
			this.CallListSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of List
		/// </summary>
		protected virtual void CallListSuperConstructors(ListBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: ListItem()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ContentContainer</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>ContentContainer</li>
		///     <li>Content</li>
		/// </ul>
		public virtual void ListItem(ListItemBuilder _this)
		{
			this.CallListItemSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ListItem
		/// </summary>
		protected virtual void CallListItemSuperConstructors(ListItemBuilder _this)
		{
			this.ContentContainer(_this);
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Table()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>RowCount</li>
		/// </ul>
		public virtual void Table(TableBuilder _this)
		{
			this.CallTableSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Table
		/// </summary>
		protected virtual void CallTableSuperConstructors(TableBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: TableCell()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ContentContainer</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>ContentContainer</li>
		///     <li>Content</li>
		/// </ul>
		public virtual void TableCell(TableCellBuilder _this)
		{
			this.CallTableCellSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TableCell
		/// </summary>
		protected virtual void CallTableCellSuperConstructors(TableCellBuilder _this)
		{
			this.ContentContainer(_this);
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Image()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void Image(ImageBuilder _this)
		{
			this.CallImageSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Image
		/// </summary>
		protected virtual void CallImageSuperConstructors(ImageBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: LineBreak()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void LineBreak(LineBreakBuilder _this)
		{
			this.CallLineBreakSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LineBreak
		/// </summary>
		protected virtual void CallLineBreakSuperConstructors(LineBreakBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: PageBreak()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void PageBreak(PageBreakBuilder _this)
		{
			this.CallPageBreakSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of PageBreak
		/// </summary>
		protected virtual void CallPageBreakSuperConstructors(PageBreakBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: TableOfContents()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void TableOfContents(TableOfContentsBuilder _this)
		{
			this.CallTableOfContentsSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TableOfContents
		/// </summary>
		protected virtual void CallTableOfContentsSuperConstructors(TableOfContentsBuilder _this)
		{
			this.Content(_this);
		}
	
	
	
	
	
	}

	internal class DocumentModelImplementationProvider
	{
		// If there is a compile error at this line, create a new class called DocumentModelImplementation
		// which is a subclass of global::DevToolsX.Documents.Symbols.Internal.DocumentModelImplementationBase:
		private static DocumentModelImplementation implementation = new DocumentModelImplementation();
	
		public static DocumentModelImplementation Implementation
		{
			get { return implementation; }
		}
	}
}
