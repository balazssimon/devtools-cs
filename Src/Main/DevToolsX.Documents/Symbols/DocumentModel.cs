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
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Document_Sections;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Section;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Section_Title;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Section_Subsections;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Section_Paragraphs;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Content;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass ContentList;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty ContentList_Items;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Paragraph;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Paragraph_Alignment;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Paragraph_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Text_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Label;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Label_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Reference;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Reference_Target;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Reference_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Markup;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Markup_Kind;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Markup_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass List;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty List_Items;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass ListItem;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty ListItem_Title;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty ListItem_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Table;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_HeadColumnCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_HeadRowCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_ColumnCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_RowCount;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Table_Cells;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Cell;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Cell_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Image;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Image_FilePath;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass PageBreak;
	
		static DocumentModelInstance()
		{
			DocumentModelBuilderInstance.instance.Create();
			DocumentModelBuilderInstance.instance.EvaluateLazyValues();
			MetaModel = DocumentModelBuilderInstance.instance.MetaModel.ToImmutable();
			Model = DocumentModelBuilderInstance.instance.Model.ToImmutable();
	
	
			Document = DocumentModelBuilderInstance.instance.Document.ToImmutable(Model);
			Document_Title = DocumentModelBuilderInstance.instance.Document_Title.ToImmutable(Model);
			Document_Sections = DocumentModelBuilderInstance.instance.Document_Sections.ToImmutable(Model);
			Section = DocumentModelBuilderInstance.instance.Section.ToImmutable(Model);
			Section_Title = DocumentModelBuilderInstance.instance.Section_Title.ToImmutable(Model);
			Section_Subsections = DocumentModelBuilderInstance.instance.Section_Subsections.ToImmutable(Model);
			Section_Paragraphs = DocumentModelBuilderInstance.instance.Section_Paragraphs.ToImmutable(Model);
			Content = DocumentModelBuilderInstance.instance.Content.ToImmutable(Model);
			ContentList = DocumentModelBuilderInstance.instance.ContentList.ToImmutable(Model);
			ContentList_Items = DocumentModelBuilderInstance.instance.ContentList_Items.ToImmutable(Model);
			Paragraph = DocumentModelBuilderInstance.instance.Paragraph.ToImmutable(Model);
			Paragraph_Alignment = DocumentModelBuilderInstance.instance.Paragraph_Alignment.ToImmutable(Model);
			Paragraph_Text = DocumentModelBuilderInstance.instance.Paragraph_Text.ToImmutable(Model);
			Text = DocumentModelBuilderInstance.instance.Text.ToImmutable(Model);
			Text_Text = DocumentModelBuilderInstance.instance.Text_Text.ToImmutable(Model);
			Label = DocumentModelBuilderInstance.instance.Label.ToImmutable(Model);
			Label_Name = DocumentModelBuilderInstance.instance.Label_Name.ToImmutable(Model);
			Reference = DocumentModelBuilderInstance.instance.Reference.ToImmutable(Model);
			Reference_Target = DocumentModelBuilderInstance.instance.Reference_Target.ToImmutable(Model);
			Reference_Text = DocumentModelBuilderInstance.instance.Reference_Text.ToImmutable(Model);
			Markup = DocumentModelBuilderInstance.instance.Markup.ToImmutable(Model);
			Markup_Kind = DocumentModelBuilderInstance.instance.Markup_Kind.ToImmutable(Model);
			Markup_Text = DocumentModelBuilderInstance.instance.Markup_Text.ToImmutable(Model);
			List = DocumentModelBuilderInstance.instance.List.ToImmutable(Model);
			List_Items = DocumentModelBuilderInstance.instance.List_Items.ToImmutable(Model);
			ListItem = DocumentModelBuilderInstance.instance.ListItem.ToImmutable(Model);
			ListItem_Title = DocumentModelBuilderInstance.instance.ListItem_Title.ToImmutable(Model);
			ListItem_Text = DocumentModelBuilderInstance.instance.ListItem_Text.ToImmutable(Model);
			Table = DocumentModelBuilderInstance.instance.Table.ToImmutable(Model);
			Table_HeadColumnCount = DocumentModelBuilderInstance.instance.Table_HeadColumnCount.ToImmutable(Model);
			Table_HeadRowCount = DocumentModelBuilderInstance.instance.Table_HeadRowCount.ToImmutable(Model);
			Table_ColumnCount = DocumentModelBuilderInstance.instance.Table_ColumnCount.ToImmutable(Model);
			Table_RowCount = DocumentModelBuilderInstance.instance.Table_RowCount.ToImmutable(Model);
			Table_Cells = DocumentModelBuilderInstance.instance.Table_Cells.ToImmutable(Model);
			Cell = DocumentModelBuilderInstance.instance.Cell.ToImmutable(Model);
			Cell_Text = DocumentModelBuilderInstance.instance.Cell_Text.ToImmutable(Model);
			Image = DocumentModelBuilderInstance.instance.Image.ToImmutable(Model);
			Image_FilePath = DocumentModelBuilderInstance.instance.Image_FilePath.ToImmutable(Model);
			PageBreak = DocumentModelBuilderInstance.instance.PageBreak.ToImmutable(Model);
	
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
				case "Section": return this.Section();
				case "ContentList": return this.ContentList();
				case "Paragraph": return this.Paragraph();
				case "Text": return this.Text();
				case "Label": return this.Label();
				case "Reference": return this.Reference();
				case "Markup": return this.Markup();
				case "List": return this.List();
				case "ListItem": return this.ListItem();
				case "Table": return this.Table();
				case "Cell": return this.Cell();
				case "Image": return this.Image();
				case "PageBreak": return this.PageBreak();
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
		/// Creates a new instance of Section.
		/// </summary>
		public SectionBuilder Section()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new SectionId());
			return (SectionBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of ContentList.
		/// </summary>
		public ContentListBuilder ContentList()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ContentListId());
			return (ContentListBuilder)symbol;
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
		/// Creates a new instance of Cell.
		/// </summary>
		public CellBuilder Cell()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new CellId());
			return (CellBuilder)symbol;
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
		/// Creates a new instance of PageBreak.
		/// </summary>
		public PageBreakBuilder PageBreak()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new PageBreakId());
			return (PageBreakBuilder)symbol;
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
	
	public interface Document : global::MetaDslx.Core.ImmutableSymbol
	{
		string Title { get; }
		global::MetaDslx.Core.ImmutableModelList<Section> Sections { get; }
	
	
		new DocumentBuilder ToMutable();
		new DocumentBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DocumentBuilder : global::MetaDslx.Core.MutableSymbol
	{
		string Title { get; set; }
		Func<string> TitleLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<SectionBuilder> Sections { get; }
	
		new Document ToImmutable();
		new Document ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Section : global::MetaDslx.Core.ImmutableSymbol
	{
		string Title { get; }
		global::MetaDslx.Core.ImmutableModelList<Section> Subsections { get; }
		global::MetaDslx.Core.ImmutableModelList<Paragraph> Paragraphs { get; }
	
	
		new SectionBuilder ToMutable();
		new SectionBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface SectionBuilder : global::MetaDslx.Core.MutableSymbol
	{
		string Title { get; set; }
		Func<string> TitleLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<SectionBuilder> Subsections { get; }
		global::MetaDslx.Core.MutableModelList<ParagraphBuilder> Paragraphs { get; }
	
		new Section ToImmutable();
		new Section ToImmutable(global::MetaDslx.Core.ImmutableModel model);
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
	
	public interface ContentList : Content
	{
		global::MetaDslx.Core.ImmutableModelList<Content> Items { get; }
	
	
		new ContentListBuilder ToMutable();
		new ContentListBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ContentListBuilder : ContentBuilder
	{
		global::MetaDslx.Core.MutableModelList<ContentBuilder> Items { get; }
	
		new ContentList ToImmutable();
		new ContentList ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Paragraph : Content
	{
		HorizontalAlignment Alignment { get; }
		Content Text { get; }
	
	
		new ParagraphBuilder ToMutable();
		new ParagraphBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ParagraphBuilder : ContentBuilder
	{
		HorizontalAlignment Alignment { get; set; }
		Func<HorizontalAlignment> AlignmentLazy { get; set; }
		ContentBuilder Text { get; set; }
		Func<ContentBuilder> TextLazy { get; set; }
	
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
	
	public interface Reference : Content
	{
		Label Target { get; }
		Content Text { get; }
	
	
		new ReferenceBuilder ToMutable();
		new ReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ReferenceBuilder : ContentBuilder
	{
		LabelBuilder Target { get; set; }
		Func<LabelBuilder> TargetLazy { get; set; }
		ContentBuilder Text { get; set; }
		Func<ContentBuilder> TextLazy { get; set; }
	
		new Reference ToImmutable();
		new Reference ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Markup : Content
	{
		MarkupKind Kind { get; }
		Content Text { get; }
	
	
		new MarkupBuilder ToMutable();
		new MarkupBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MarkupBuilder : ContentBuilder
	{
		MarkupKind Kind { get; set; }
		Func<MarkupKind> KindLazy { get; set; }
		ContentBuilder Text { get; set; }
		Func<ContentBuilder> TextLazy { get; set; }
	
		new Markup ToImmutable();
		new Markup ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface List : Content
	{
		global::MetaDslx.Core.ImmutableModelList<ListItem> Items { get; }
	
	
		new ListBuilder ToMutable();
		new ListBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ListBuilder : ContentBuilder
	{
		global::MetaDslx.Core.MutableModelList<ListItemBuilder> Items { get; }
	
		new List ToImmutable();
		new List ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface ListItem : global::MetaDslx.Core.ImmutableSymbol
	{
		string Title { get; }
		Content Text { get; }
	
	
		new ListItemBuilder ToMutable();
		new ListItemBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ListItemBuilder : global::MetaDslx.Core.MutableSymbol
	{
		string Title { get; set; }
		Func<string> TitleLazy { get; set; }
		ContentBuilder Text { get; set; }
		Func<ContentBuilder> TextLazy { get; set; }
	
		new ListItem ToImmutable();
		new ListItem ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Table : Content
	{
		int HeadColumnCount { get; }
		int HeadRowCount { get; }
		int ColumnCount { get; }
		int RowCount { get; }
		global::MetaDslx.Core.ImmutableModelList<Cell> Cells { get; }
	
	
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
		global::MetaDslx.Core.MutableModelList<CellBuilder> Cells { get; }
	
		new Table ToImmutable();
		new Table ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Cell : global::MetaDslx.Core.ImmutableSymbol
	{
		Content Text { get; }
	
	
		new CellBuilder ToMutable();
		new CellBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface CellBuilder : global::MetaDslx.Core.MutableSymbol
	{
		ContentBuilder Text { get; set; }
		Func<ContentBuilder> TextLazy { get; set; }
	
		new Cell ToImmutable();
		new Cell ToImmutable(global::MetaDslx.Core.ImmutableModel model);
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

	public static class DocumentModelDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty> properties;
	
		static DocumentModelDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty>();
			Document.Initialize();
			Section.Initialize();
			Content.Initialize();
			ContentList.Initialize();
			Paragraph.Initialize();
			Text.Initialize();
			Label.Initialize();
			Reference.Initialize();
			Markup.Initialize();
			List.Initialize();
			ListItem.Initialize();
			Table.Initialize();
			Cell.Initialize();
			Image.Initialize();
			PageBreak.Initialize();
			properties.Add(DocumentModelDescriptor.Document.TitleProperty);
			properties.Add(DocumentModelDescriptor.Document.SectionsProperty);
			properties.Add(DocumentModelDescriptor.Section.TitleProperty);
			properties.Add(DocumentModelDescriptor.Section.SubsectionsProperty);
			properties.Add(DocumentModelDescriptor.Section.ParagraphsProperty);
			properties.Add(DocumentModelDescriptor.ContentList.ItemsProperty);
			properties.Add(DocumentModelDescriptor.Paragraph.AlignmentProperty);
			properties.Add(DocumentModelDescriptor.Paragraph.TextProperty);
			properties.Add(DocumentModelDescriptor.Text.TextProperty);
			properties.Add(DocumentModelDescriptor.Label.NameProperty);
			properties.Add(DocumentModelDescriptor.Reference.TargetProperty);
			properties.Add(DocumentModelDescriptor.Reference.TextProperty);
			properties.Add(DocumentModelDescriptor.Markup.KindProperty);
			properties.Add(DocumentModelDescriptor.Markup.TextProperty);
			properties.Add(DocumentModelDescriptor.List.ItemsProperty);
			properties.Add(DocumentModelDescriptor.ListItem.TitleProperty);
			properties.Add(DocumentModelDescriptor.ListItem.TextProperty);
			properties.Add(DocumentModelDescriptor.Table.HeadColumnCountProperty);
			properties.Add(DocumentModelDescriptor.Table.HeadRowCountProperty);
			properties.Add(DocumentModelDescriptor.Table.ColumnCountProperty);
			properties.Add(DocumentModelDescriptor.Table.RowCountProperty);
			properties.Add(DocumentModelDescriptor.Table.CellsProperty);
			properties.Add(DocumentModelDescriptor.Cell.TextProperty);
			properties.Add(DocumentModelDescriptor.Image.FilePathProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "http://devtoolsx.documents.documentmodel/1.0";
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Document), typeof(global::DevToolsX.Documents.Symbols.DocumentBuilder))]
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
			
			public static readonly global::MetaDslx.Core.ModelProperty TitleProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Document), "Title",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Document_Title);
			
			public static readonly global::MetaDslx.Core.ModelProperty SectionsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Document), "Sections",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Section), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.Section>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.SectionBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.SectionBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Document_Sections);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Section), typeof(global::DevToolsX.Documents.Symbols.SectionBuilder))]
		public static class Section
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Section()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Section));
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
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Section; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty TitleProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Section), "Title",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Section_Title);
			
			public static readonly global::MetaDslx.Core.ModelProperty SubsectionsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Section), "Subsections",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Section), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.Section>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.SectionBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.SectionBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Section_Subsections);
			
			public static readonly global::MetaDslx.Core.ModelProperty ParagraphsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Section), "Paragraphs",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Paragraph), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.Paragraph>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ParagraphBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.ParagraphBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Section_Paragraphs);
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
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.ContentList), typeof(global::DevToolsX.Documents.Symbols.ContentListBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
		public static class ContentList
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static ContentList()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ContentList));
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
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.ContentList; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty ItemsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ContentList), "Items",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Content), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.Content>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ContentBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.ContentBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.ContentList_Items);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Paragraph), typeof(global::DevToolsX.Documents.Symbols.ParagraphBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
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
			
			public static readonly global::MetaDslx.Core.ModelProperty TextProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Paragraph), "Text",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Content), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ContentBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Paragraph_Text);
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
			
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Label), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Label_Name);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Reference), typeof(global::DevToolsX.Documents.Symbols.ReferenceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
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
			
			public static readonly global::MetaDslx.Core.ModelProperty TargetProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Reference), "Target",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Label), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.LabelBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Reference_Target);
			
			public static readonly global::MetaDslx.Core.ModelProperty TextProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Reference), "Text",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Content), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ContentBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Reference_Text);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Markup), typeof(global::DevToolsX.Documents.Symbols.MarkupBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(DocumentModelDescriptor.Content) })]
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
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.MarkupKind), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.MarkupKind), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Markup_Kind);
			
			public static readonly global::MetaDslx.Core.ModelProperty TextProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Markup), "Text",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Content), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ContentBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Markup_Text);
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
			
			public static readonly global::MetaDslx.Core.ModelProperty ItemsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(List), "Items",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ListItem), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.ListItem>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ListItemBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.ListItemBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.List_Items);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.ListItem), typeof(global::DevToolsX.Documents.Symbols.ListItemBuilder))]
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
			
			public static readonly global::MetaDslx.Core.ModelProperty TitleProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ListItem), "Title",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.ListItem_Title);
			
			public static readonly global::MetaDslx.Core.ModelProperty TextProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ListItem), "Text",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Content), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ContentBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.ListItem_Text);
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
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Cell), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Symbols.Cell>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.CellBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Symbols.CellBuilder>)),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Table_Cells);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Symbols.Cell), typeof(global::DevToolsX.Documents.Symbols.CellBuilder))]
		public static class Cell
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Cell()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Cell));
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
				get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.Cell; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty TextProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Cell), "Text",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.Content), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Symbols.ContentBuilder), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Cell_Text);
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
			
			public static readonly global::MetaDslx.Core.ModelProperty FilePathProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Image), "FilePath",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Symbols.DocumentModelInstance.Image_FilePath);
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
		private global::MetaDslx.Core.ImmutableModelList<Section> sections0;
	
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
	
		
		public string Title
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.TitleProperty, ref title0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Section> Sections
		{
		    get { return this.GetList<Section>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.SectionsProperty, ref sections0); }
		}
	}
	
	internal class DocumentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DocumentBuilder
	{
		private global::MetaDslx.Core.MutableModelList<SectionBuilder> sections0;
	
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
	
		
		public global::MetaDslx.Core.MutableModelList<SectionBuilder> Sections
		{
			get { return this.GetList<SectionBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Document.SectionsProperty, ref sections0); }
		}
	}
	
	internal class SectionId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new SectionImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new SectionBuilderImpl(this, model, creating);
		}
	}
	
	internal class SectionImpl : global::MetaDslx.Core.ImmutableSymbolBase, Section
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string title0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Section> subsections0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Paragraph> paragraphs0;
	
		internal SectionImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Section; }
		}
	
		public new SectionBuilder ToMutable()
		{
			return (SectionBuilder)base.ToMutable();
		}
	
		public new SectionBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (SectionBuilder)base.ToMutable(model);
		}
	
		
		public string Title
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.TitleProperty, ref title0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Section> Subsections
		{
		    get { return this.GetList<Section>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.SubsectionsProperty, ref subsections0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Paragraph> Paragraphs
		{
		    get { return this.GetList<Paragraph>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.ParagraphsProperty, ref paragraphs0); }
		}
	}
	
	internal class SectionBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, SectionBuilder
	{
		private global::MetaDslx.Core.MutableModelList<SectionBuilder> subsections0;
		private global::MetaDslx.Core.MutableModelList<ParagraphBuilder> paragraphs0;
	
		internal SectionBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Section(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Section; }
		}
	
		public new Section ToImmutable()
		{
			return (Section)base.ToImmutable();
		}
	
		public new Section ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Section)base.ToImmutable(model);
		}
	
		
		public string Title
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.TitleProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.TitleProperty, value); }
		}
		
		public Func<string> TitleLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.TitleProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Section.TitleProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<SectionBuilder> Subsections
		{
			get { return this.GetList<SectionBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.SubsectionsProperty, ref subsections0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ParagraphBuilder> Paragraphs
		{
			get { return this.GetList<ParagraphBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Section.ParagraphsProperty, ref paragraphs0); }
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
	
	internal class ContentListId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentList.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ContentListImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ContentListBuilderImpl(this, model, creating);
		}
	}
	
	internal class ContentListImpl : global::MetaDslx.Core.ImmutableSymbolBase, ContentList
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Content> items0;
	
		internal ContentListImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.ContentList; }
		}
	
		public new ContentListBuilder ToMutable()
		{
			return (ContentListBuilder)base.ToMutable();
		}
	
		public new ContentListBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ContentListBuilder)base.ToMutable(model);
		}
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Content> Items
		{
		    get { return this.GetList<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentList.ItemsProperty, ref items0); }
		}
	}
	
	internal class ContentListBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ContentListBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ContentBuilder> items0;
	
		internal ContentListBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.ContentList(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.ContentList; }
		}
	
		public new ContentList ToImmutable()
		{
			return (ContentList)base.ToImmutable();
		}
	
		public new ContentList ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (ContentList)base.ToImmutable(model);
		}
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ContentBuilder> Items
		{
			get { return this.GetList<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ContentList.ItemsProperty, ref items0); }
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
		private Content text0;
	
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
	
		
		public Content Text
		{
		    get { return this.GetReference<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.TextProperty, ref text0); }
		}
	}
	
	internal class ParagraphBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ParagraphBuilder
	{
	
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
	
		
		public ContentBuilder Text
		{
			get { return this.GetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.TextProperty); }
			set { this.SetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.TextProperty, value); }
		}
		
		public Func<ContentBuilder> TextLazy
		{
			get { return this.GetLazyReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Paragraph.TextProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Paragraph.TextProperty, value); }
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
		private Label target0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Content text0;
	
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
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public Label Target
		{
		    get { return this.GetReference<Label>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TargetProperty, ref target0); }
		}
	
		
		public Content Text
		{
		    get { return this.GetReference<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TextProperty, ref text0); }
		}
	}
	
	internal class ReferenceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ReferenceBuilder
	{
	
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
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		
		public ContentBuilder Text
		{
			get { return this.GetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TextProperty); }
			set { this.SetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TextProperty, value); }
		}
		
		public Func<ContentBuilder> TextLazy
		{
			get { return this.GetLazyReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Reference.TextProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Reference.TextProperty, value); }
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
		private MarkupKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Content text0;
	
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
	
		ContentBuilder Content.ToMutable()
		{
			return this.ToMutable();
		}
	
		ContentBuilder Content.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public MarkupKind Kind
		{
		    get { return this.GetValue<MarkupKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.KindProperty, ref kind0); }
		}
	
		
		public Content Text
		{
		    get { return this.GetReference<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.TextProperty, ref text0); }
		}
	}
	
	internal class MarkupBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MarkupBuilder
	{
	
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
	
		Content ContentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Content ContentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public MarkupKind Kind
		{
			get { return this.GetValue<MarkupKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.KindProperty); }
			set { this.SetValue<MarkupKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.KindProperty, value); }
		}
		
		public Func<MarkupKind> KindLazy
		{
			get { return this.GetLazyValue<MarkupKind>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.KindProperty); }
			set { this.SetLazyValue(DocumentModelDescriptor.Markup.KindProperty, value); }
		}
	
		
		public ContentBuilder Text
		{
			get { return this.GetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.TextProperty); }
			set { this.SetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.TextProperty, value); }
		}
		
		public Func<ContentBuilder> TextLazy
		{
			get { return this.GetLazyReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Markup.TextProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Markup.TextProperty, value); }
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
		private Content text0;
	
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
	
		
		public string Title
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TitleProperty, ref title0); }
		}
	
		
		public Content Text
		{
		    get { return this.GetReference<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TextProperty, ref text0); }
		}
	}
	
	internal class ListItemBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ListItemBuilder
	{
	
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
	
		
		public ContentBuilder Text
		{
			get { return this.GetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TextProperty); }
			set { this.SetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TextProperty, value); }
		}
		
		public Func<ContentBuilder> TextLazy
		{
			get { return this.GetLazyReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.ListItem.TextProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.ListItem.TextProperty, value); }
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
		private global::MetaDslx.Core.ImmutableModelList<Cell> cells0;
	
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<Cell> Cells
		{
		    get { return this.GetList<Cell>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.CellsProperty, ref cells0); }
		}
	}
	
	internal class TableBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TableBuilder
	{
		private global::MetaDslx.Core.MutableModelList<CellBuilder> cells0;
	
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
	
		
		public global::MetaDslx.Core.MutableModelList<CellBuilder> Cells
		{
			get { return this.GetList<CellBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Table.CellsProperty, ref cells0); }
		}
	}
	
	internal class CellId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Cell.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new CellImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new CellBuilderImpl(this, model, creating);
		}
	}
	
	internal class CellImpl : global::MetaDslx.Core.ImmutableSymbolBase, Cell
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Content text0;
	
		internal CellImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Cell; }
		}
	
		public new CellBuilder ToMutable()
		{
			return (CellBuilder)base.ToMutable();
		}
	
		public new CellBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (CellBuilder)base.ToMutable(model);
		}
	
		
		public Content Text
		{
		    get { return this.GetReference<Content>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Cell.TextProperty, ref text0); }
		}
	}
	
	internal class CellBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, CellBuilder
	{
	
		internal CellBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			DocumentModelImplementationProvider.Implementation.Cell(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Symbols.DocumentModelInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return DocumentModelInstance.Cell; }
		}
	
		public new Cell ToImmutable()
		{
			return (Cell)base.ToImmutable();
		}
	
		public new Cell ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Cell)base.ToImmutable(model);
		}
	
		
		public ContentBuilder Text
		{
			get { return this.GetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Cell.TextProperty); }
			set { this.SetReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Cell.TextProperty, value); }
		}
		
		public Func<ContentBuilder> TextLazy
		{
			get { return this.GetLazyReference<ContentBuilder>(global::DevToolsX.Documents.Symbols.DocumentModelDescriptor.Cell.TextProperty); }
			set { this.SetLazyReference(DocumentModelDescriptor.Cell.TextProperty, value); }
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
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Document;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Document_Title;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Document_Sections;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Section;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Section_Title;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Section_Subsections;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Section_Paragraphs;
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
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Content;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ContentList;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder ContentList_Items;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Paragraph;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Paragraph_Alignment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Paragraph_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Text_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Label;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Label_Name;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Reference;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Reference_Target;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Reference_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Markup;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Markup_Kind;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Markup_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder List;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder List_Items;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ListItem;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder ListItem_Title;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder ListItem_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Table;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_HeadColumnCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_HeadRowCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_ColumnCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_RowCount;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Table_Cells;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Cell;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Cell_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Image;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Image_FilePath;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder PageBreak;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp19;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp20;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp21;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp22;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp24;
	
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
			Document = factory.MetaClass();
			Document_Title = factory.MetaProperty();
			Document_Sections = factory.MetaProperty();
			Section = factory.MetaClass();
			Section_Title = factory.MetaProperty();
			Section_Subsections = factory.MetaProperty();
			Section_Paragraphs = factory.MetaProperty();
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
			Content = factory.MetaClass();
			ContentList = factory.MetaClass();
			ContentList_Items = factory.MetaProperty();
			Paragraph = factory.MetaClass();
			Paragraph_Alignment = factory.MetaProperty();
			Paragraph_Text = factory.MetaProperty();
			Text = factory.MetaClass();
			Text_Text = factory.MetaProperty();
			Label = factory.MetaClass();
			Label_Name = factory.MetaProperty();
			Reference = factory.MetaClass();
			Reference_Target = factory.MetaProperty();
			Reference_Text = factory.MetaProperty();
			Markup = factory.MetaClass();
			Markup_Kind = factory.MetaProperty();
			Markup_Text = factory.MetaProperty();
			List = factory.MetaClass();
			List_Items = factory.MetaProperty();
			ListItem = factory.MetaClass();
			ListItem_Title = factory.MetaProperty();
			ListItem_Text = factory.MetaProperty();
			Table = factory.MetaClass();
			Table_HeadColumnCount = factory.MetaProperty();
			Table_HeadRowCount = factory.MetaProperty();
			Table_ColumnCount = factory.MetaProperty();
			Table_RowCount = factory.MetaProperty();
			Table_Cells = factory.MetaProperty();
			Cell = factory.MetaClass();
			Cell_Text = factory.MetaProperty();
			Image = factory.MetaClass();
			Image_FilePath = factory.MetaProperty();
			PageBreak = factory.MetaClass();
			__tmp19 = factory.MetaCollectionType();
			__tmp20 = factory.MetaCollectionType();
			__tmp21 = factory.MetaCollectionType();
			__tmp22 = factory.MetaCollectionType();
			__tmp23 = factory.MetaCollectionType();
			__tmp24 = factory.MetaCollectionType();
	
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
			__tmp3.Declarations.AddLazy(() => Document);
			__tmp3.Declarations.AddLazy(() => Section);
			__tmp3.Declarations.AddLazy(() => MarkupKind);
			__tmp3.Declarations.AddLazy(() => HorizontalAlignment);
			__tmp3.Declarations.AddLazy(() => Content);
			__tmp3.Declarations.AddLazy(() => ContentList);
			__tmp3.Declarations.AddLazy(() => Paragraph);
			__tmp3.Declarations.AddLazy(() => Text);
			__tmp3.Declarations.AddLazy(() => Label);
			__tmp3.Declarations.AddLazy(() => Reference);
			__tmp3.Declarations.AddLazy(() => Markup);
			__tmp3.Declarations.AddLazy(() => List);
			__tmp3.Declarations.AddLazy(() => ListItem);
			__tmp3.Declarations.AddLazy(() => Table);
			__tmp3.Declarations.AddLazy(() => Cell);
			__tmp3.Declarations.AddLazy(() => Image);
			__tmp3.Declarations.AddLazy(() => PageBreak);
			__tmp4.Name = "DocumentModel";
			__tmp4.Documentation = null;
			__tmp4.Uri = "http://devtoolsx.documents.documentmodel/1.0";
			__tmp4.NamespaceLazy = () => __tmp3;
			Document.MetaModelLazy = () => __tmp4;
			Document.NamespaceLazy = () => __tmp3;
			Document.Documentation = null;
			Document.Name = "Document";
			// Document.IsAbstract = null;
			Document.Properties.AddLazy(() => Document_Title);
			Document.Properties.AddLazy(() => Document_Sections);
			Document_Title.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Document_Title.Name = "Title";
			Document_Title.Documentation = null;
			// Document_Title.Kind = null;
			Document_Title.ClassLazy = () => Document;
			Document_Sections.TypeLazy = () => __tmp20;
			Document_Sections.Name = "Sections";
			Document_Sections.Documentation = null;
			// Document_Sections.Kind = null;
			Document_Sections.ClassLazy = () => Document;
			Section.MetaModelLazy = () => __tmp4;
			Section.NamespaceLazy = () => __tmp3;
			Section.Documentation = null;
			Section.Name = "Section";
			// Section.IsAbstract = null;
			Section.Properties.AddLazy(() => Section_Title);
			Section.Properties.AddLazy(() => Section_Subsections);
			Section.Properties.AddLazy(() => Section_Paragraphs);
			Section_Title.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Section_Title.Name = "Title";
			Section_Title.Documentation = null;
			// Section_Title.Kind = null;
			Section_Title.ClassLazy = () => Section;
			Section_Subsections.TypeLazy = () => __tmp24;
			Section_Subsections.Name = "Subsections";
			Section_Subsections.Documentation = null;
			// Section_Subsections.Kind = null;
			Section_Subsections.ClassLazy = () => Section;
			Section_Paragraphs.TypeLazy = () => __tmp21;
			Section_Paragraphs.Name = "Paragraphs";
			Section_Paragraphs.Documentation = null;
			// Section_Paragraphs.Kind = null;
			Section_Paragraphs.ClassLazy = () => Section;
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
			Content.MetaModelLazy = () => __tmp4;
			Content.NamespaceLazy = () => __tmp3;
			Content.Documentation = null;
			Content.Name = "Content";
			Content.IsAbstract = true;
			ContentList.MetaModelLazy = () => __tmp4;
			ContentList.NamespaceLazy = () => __tmp3;
			ContentList.Documentation = null;
			ContentList.Name = "ContentList";
			// ContentList.IsAbstract = null;
			ContentList.SuperClasses.AddLazy(() => Content);
			ContentList.Properties.AddLazy(() => ContentList_Items);
			ContentList_Items.TypeLazy = () => __tmp23;
			ContentList_Items.Name = "Items";
			ContentList_Items.Documentation = null;
			// ContentList_Items.Kind = null;
			ContentList_Items.ClassLazy = () => ContentList;
			Paragraph.MetaModelLazy = () => __tmp4;
			Paragraph.NamespaceLazy = () => __tmp3;
			Paragraph.Documentation = null;
			Paragraph.Name = "Paragraph";
			// Paragraph.IsAbstract = null;
			Paragraph.SuperClasses.AddLazy(() => Content);
			Paragraph.Properties.AddLazy(() => Paragraph_Alignment);
			Paragraph.Properties.AddLazy(() => Paragraph_Text);
			Paragraph_Alignment.TypeLazy = () => HorizontalAlignment;
			Paragraph_Alignment.Name = "Alignment";
			Paragraph_Alignment.Documentation = null;
			// Paragraph_Alignment.Kind = null;
			Paragraph_Alignment.ClassLazy = () => Paragraph;
			Paragraph_Text.TypeLazy = () => Content;
			Paragraph_Text.Name = "Text";
			Paragraph_Text.Documentation = null;
			// Paragraph_Text.Kind = null;
			Paragraph_Text.ClassLazy = () => Paragraph;
			Text.MetaModelLazy = () => __tmp4;
			Text.NamespaceLazy = () => __tmp3;
			Text.Documentation = null;
			Text.Name = "Text";
			// Text.IsAbstract = null;
			Text.SuperClasses.AddLazy(() => Content);
			Text.Properties.AddLazy(() => Text_Text);
			Text_Text.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Text_Text.Name = "Text";
			Text_Text.Documentation = null;
			// Text_Text.Kind = null;
			Text_Text.ClassLazy = () => Text;
			Label.MetaModelLazy = () => __tmp4;
			Label.NamespaceLazy = () => __tmp3;
			Label.Documentation = null;
			Label.Name = "Label";
			// Label.IsAbstract = null;
			Label.SuperClasses.AddLazy(() => Content);
			Label.Properties.AddLazy(() => Label_Name);
			Label_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Label_Name.Name = "Name";
			Label_Name.Documentation = null;
			// Label_Name.Kind = null;
			Label_Name.ClassLazy = () => Label;
			Reference.MetaModelLazy = () => __tmp4;
			Reference.NamespaceLazy = () => __tmp3;
			Reference.Documentation = null;
			Reference.Name = "Reference";
			// Reference.IsAbstract = null;
			Reference.SuperClasses.AddLazy(() => Content);
			Reference.Properties.AddLazy(() => Reference_Target);
			Reference.Properties.AddLazy(() => Reference_Text);
			Reference_Target.TypeLazy = () => Label;
			Reference_Target.Name = "Target";
			Reference_Target.Documentation = null;
			// Reference_Target.Kind = null;
			Reference_Target.ClassLazy = () => Reference;
			Reference_Text.TypeLazy = () => Content;
			Reference_Text.Name = "Text";
			Reference_Text.Documentation = null;
			// Reference_Text.Kind = null;
			Reference_Text.ClassLazy = () => Reference;
			Markup.MetaModelLazy = () => __tmp4;
			Markup.NamespaceLazy = () => __tmp3;
			Markup.Documentation = null;
			Markup.Name = "Markup";
			// Markup.IsAbstract = null;
			Markup.SuperClasses.AddLazy(() => Content);
			Markup.Properties.AddLazy(() => Markup_Kind);
			Markup.Properties.AddLazy(() => Markup_Text);
			Markup_Kind.TypeLazy = () => MarkupKind;
			Markup_Kind.Name = "Kind";
			Markup_Kind.Documentation = null;
			// Markup_Kind.Kind = null;
			Markup_Kind.ClassLazy = () => Markup;
			Markup_Text.TypeLazy = () => Content;
			Markup_Text.Name = "Text";
			Markup_Text.Documentation = null;
			// Markup_Text.Kind = null;
			Markup_Text.ClassLazy = () => Markup;
			List.MetaModelLazy = () => __tmp4;
			List.NamespaceLazy = () => __tmp3;
			List.Documentation = null;
			List.Name = "List";
			// List.IsAbstract = null;
			List.SuperClasses.AddLazy(() => Content);
			List.Properties.AddLazy(() => List_Items);
			List_Items.TypeLazy = () => __tmp19;
			List_Items.Name = "Items";
			List_Items.Documentation = null;
			// List_Items.Kind = null;
			List_Items.ClassLazy = () => List;
			ListItem.MetaModelLazy = () => __tmp4;
			ListItem.NamespaceLazy = () => __tmp3;
			ListItem.Documentation = null;
			ListItem.Name = "ListItem";
			// ListItem.IsAbstract = null;
			ListItem.Properties.AddLazy(() => ListItem_Title);
			ListItem.Properties.AddLazy(() => ListItem_Text);
			ListItem_Title.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			ListItem_Title.Name = "Title";
			ListItem_Title.Documentation = null;
			// ListItem_Title.Kind = null;
			ListItem_Title.ClassLazy = () => ListItem;
			ListItem_Text.TypeLazy = () => Content;
			ListItem_Text.Name = "Text";
			ListItem_Text.Documentation = null;
			// ListItem_Text.Kind = null;
			ListItem_Text.ClassLazy = () => ListItem;
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
			Table_Cells.TypeLazy = () => __tmp22;
			Table_Cells.Name = "Cells";
			Table_Cells.Documentation = null;
			// Table_Cells.Kind = null;
			Table_Cells.ClassLazy = () => Table;
			Cell.MetaModelLazy = () => __tmp4;
			Cell.NamespaceLazy = () => __tmp3;
			Cell.Documentation = null;
			Cell.Name = "Cell";
			// Cell.IsAbstract = null;
			Cell.Properties.AddLazy(() => Cell_Text);
			Cell_Text.TypeLazy = () => Content;
			Cell_Text.Name = "Text";
			Cell_Text.Documentation = null;
			// Cell_Text.Kind = null;
			Cell_Text.ClassLazy = () => Cell;
			Image.MetaModelLazy = () => __tmp4;
			Image.NamespaceLazy = () => __tmp3;
			Image.Documentation = null;
			Image.Name = "Image";
			// Image.IsAbstract = null;
			Image.SuperClasses.AddLazy(() => Content);
			Image.Properties.AddLazy(() => Image_FilePath);
			Image_FilePath.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Image_FilePath.Name = "FilePath";
			Image_FilePath.Documentation = null;
			// Image_FilePath.Kind = null;
			Image_FilePath.ClassLazy = () => Image;
			PageBreak.MetaModelLazy = () => __tmp4;
			PageBreak.NamespaceLazy = () => __tmp3;
			PageBreak.Documentation = null;
			PageBreak.Name = "PageBreak";
			// PageBreak.IsAbstract = null;
			PageBreak.SuperClasses.AddLazy(() => Content);
			__tmp19.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp19.InnerTypeLazy = () => ListItem;
			__tmp20.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp20.InnerTypeLazy = () => Section;
			__tmp21.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp21.InnerTypeLazy = () => Paragraph;
			__tmp22.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp22.InnerTypeLazy = () => Cell;
			__tmp23.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp23.InnerTypeLazy = () => Content;
			__tmp24.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp24.InnerTypeLazy = () => Section;
	
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
		public virtual void Document(DocumentBuilder _this)
		{
			this.CallDocumentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Document
		/// </summary>
		protected virtual void CallDocumentSuperConstructors(DocumentBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: Section()
		/// </summary>
		public virtual void Section(SectionBuilder _this)
		{
			this.CallSectionSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Section
		/// </summary>
		protected virtual void CallSectionSuperConstructors(SectionBuilder _this)
		{
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
		/// Implements the constructor: ContentList()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		public virtual void ContentList(ContentListBuilder _this)
		{
			this.CallContentListSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ContentList
		/// </summary>
		protected virtual void CallContentListSuperConstructors(ContentListBuilder _this)
		{
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Paragraph()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.Content(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Markup()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Content</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
		public virtual void ListItem(ListItemBuilder _this)
		{
			this.CallListItemSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ListItem
		/// </summary>
		protected virtual void CallListItemSuperConstructors(ListItemBuilder _this)
		{
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
		/// Implements the constructor: Cell()
		/// </summary>
		public virtual void Cell(CellBuilder _this)
		{
			this.CallCellSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Cell
		/// </summary>
		protected virtual void CallCellSuperConstructors(CellBuilder _this)
		{
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
