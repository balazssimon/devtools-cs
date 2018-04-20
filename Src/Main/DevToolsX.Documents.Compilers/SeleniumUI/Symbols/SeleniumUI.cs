using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DevToolsX.Documents.Compilers.SeleniumUI.Symbols
{
	using global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Internal;

	public class SeleniumUIInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return SeleniumUIInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaModel MetaModel;
		public static readonly global::MetaDslx.Core.ImmutableModel Model;
	
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Declaration;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Declaration_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Namespace;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_Declarations;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Tag;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Tag_TypeName;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Page;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Element;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Element_Locator;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Element_Tag;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Element_Parent;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Element_Elements;
	
		static SeleniumUIInstance()
		{
			SeleniumUIBuilderInstance.instance.Create();
			SeleniumUIBuilderInstance.instance.EvaluateLazyValues();
			MetaModel = SeleniumUIBuilderInstance.instance.MetaModel.ToImmutable();
			Model = SeleniumUIBuilderInstance.instance.Model.ToImmutable();
	
	
			Declaration = SeleniumUIBuilderInstance.instance.Declaration.ToImmutable(Model);
			Declaration_Name = SeleniumUIBuilderInstance.instance.Declaration_Name.ToImmutable(Model);
			Namespace = SeleniumUIBuilderInstance.instance.Namespace.ToImmutable(Model);
			Namespace_Declarations = SeleniumUIBuilderInstance.instance.Namespace_Declarations.ToImmutable(Model);
			Tag = SeleniumUIBuilderInstance.instance.Tag.ToImmutable(Model);
			Tag_TypeName = SeleniumUIBuilderInstance.instance.Tag_TypeName.ToImmutable(Model);
			Page = SeleniumUIBuilderInstance.instance.Page.ToImmutable(Model);
			Element = SeleniumUIBuilderInstance.instance.Element.ToImmutable(Model);
			Element_Locator = SeleniumUIBuilderInstance.instance.Element_Locator.ToImmutable(Model);
			Element_Tag = SeleniumUIBuilderInstance.instance.Element_Tag.ToImmutable(Model);
			Element_Parent = SeleniumUIBuilderInstance.instance.Element_Parent.ToImmutable(Model);
			Element_Elements = SeleniumUIBuilderInstance.instance.Element_Elements.ToImmutable(Model);
	
			SeleniumUIInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class SeleniumUIFactory : global::MetaDslx.Core.ModelFactory
	{
		public SeleniumUIFactory(global::MetaDslx.Core.MutableModel model, global::MetaDslx.Core.ModelFactoryFlags flags = global::MetaDslx.Core.ModelFactoryFlags.None)
			: base(model, flags)
		{
			SeleniumUIDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Core.MutableSymbol Create(string type)
		{
			switch (type)
			{
				case "Namespace": return this.Namespace();
				case "Tag": return this.Tag();
				case "Page": return this.Page();
				case "Element": return this.Element();
				default:
					throw new global::MetaDslx.Core.ModelException(global::MetaDslx.Compiler.Diagnostics.Location.None, new global::MetaDslx.Compiler.Diagnostics.DiagnosticInfo(global::MetaDslx.Core.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of Namespace.
		/// </summary>
		public NamespaceBuilder Namespace()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new NamespaceId());
			return (NamespaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Tag.
		/// </summary>
		public TagBuilder Tag()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new TagId());
			return (TagBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Page.
		/// </summary>
		public PageBuilder Page()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new PageId());
			return (PageBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Element.
		/// </summary>
		public ElementBuilder Element()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ElementId());
			return (ElementBuilder)symbol;
		}
	}
	

	
	public interface Declaration : global::MetaDslx.Core.ImmutableSymbol
	{
		string Name { get; }
	
	
		new DeclarationBuilder ToMutable();
		new DeclarationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DeclarationBuilder : global::MetaDslx.Core.MutableSymbol
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new Declaration ToImmutable();
		new Declaration ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Namespace : Declaration
	{
		global::MetaDslx.Core.ImmutableModelList<Declaration> Declarations { get; }
	
	
		new NamespaceBuilder ToMutable();
		new NamespaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface NamespaceBuilder : DeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<DeclarationBuilder> Declarations { get; }
	
		new Namespace ToImmutable();
		new Namespace ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Tag : Declaration
	{
		string TypeName { get; }
	
	
		new TagBuilder ToMutable();
		new TagBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface TagBuilder : DeclarationBuilder
	{
		string TypeName { get; set; }
		Func<string> TypeNameLazy { get; set; }
	
		new Tag ToImmutable();
		new Tag ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Page : Element
	{
	
	
		new PageBuilder ToMutable();
		new PageBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface PageBuilder : ElementBuilder
	{
	
		new Page ToImmutable();
		new Page ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Element : Declaration
	{
		string Locator { get; }
		Tag Tag { get; }
		Element Parent { get; }
		global::MetaDslx.Core.ImmutableModelList<Element> Elements { get; }
	
	
		new ElementBuilder ToMutable();
		new ElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ElementBuilder : DeclarationBuilder
	{
		string Locator { get; set; }
		Func<string> LocatorLazy { get; set; }
		TagBuilder Tag { get; set; }
		Func<TagBuilder> TagLazy { get; set; }
		ElementBuilder Parent { get; set; }
		Func<ElementBuilder> ParentLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<ElementBuilder> Elements { get; }
	
		new Element ToImmutable();
		new Element ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}

	public static class SeleniumUIDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty> properties;
	
		static SeleniumUIDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty>();
			Declaration.Initialize();
			Namespace.Initialize();
			Tag.Initialize();
			Page.Initialize();
			Element.Initialize();
			properties.Add(SeleniumUIDescriptor.Declaration.NameProperty);
			properties.Add(SeleniumUIDescriptor.Namespace.DeclarationsProperty);
			properties.Add(SeleniumUIDescriptor.Tag.TypeNameProperty);
			properties.Add(SeleniumUIDescriptor.Element.LocatorProperty);
			properties.Add(SeleniumUIDescriptor.Element.TagProperty);
			properties.Add(SeleniumUIDescriptor.Element.ParentProperty);
			properties.Add(SeleniumUIDescriptor.Element.ElementsProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "http://DevToolsX/Documents/SeleniumUI/1.0";
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Declaration), typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.DeclarationBuilder))]
		public static class Declaration
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Declaration()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Declaration));
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
				get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Declaration; }
			}
			
			[global::MetaDslx.Core.NameAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Declaration), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Declaration_Name);
		}
	
		[global::MetaDslx.Core.ScopeAttribute]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Namespace), typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.NamespaceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SeleniumUIDescriptor.Declaration) })]
		public static class Namespace
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Namespace()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Namespace));
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
				get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Namespace; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Namespace), "Declarations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Declaration), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Declaration>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.DeclarationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.DeclarationBuilder>)),
					() => global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Namespace_Declarations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Tag), typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.TagBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SeleniumUIDescriptor.Declaration) })]
		public static class Tag
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Tag()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Tag));
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
				get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Tag; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty TypeNameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Tag), "TypeName",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Tag_TypeName);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Page), typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.PageBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SeleniumUIDescriptor.Element) })]
		public static class Page
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Page()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Page));
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
				get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Page; }
			}
		}
	
		[global::MetaDslx.Core.ScopeAttribute]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Element), typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.ElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SeleniumUIDescriptor.Declaration) })]
		public static class Element
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Element()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Element));
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
				get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Element; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty LocatorProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Element), "Locator",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Element_Locator);
			
			public static readonly global::MetaDslx.Core.ModelProperty TagProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Element), "Tag",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Tag), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.TagBuilder), null),
					() => global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Element_Tag);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SeleniumUIDescriptor.Element), "Elements")]
			public static readonly global::MetaDslx.Core.ModelProperty ParentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Element), "Parent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Element), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.ElementBuilder), null),
					() => global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Element_Parent);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SeleniumUIDescriptor.Element), "Parent")]
			public static readonly global::MetaDslx.Core.ModelProperty ElementsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Element), "Elements",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Element), typeof(global::MetaDslx.Core.ImmutableModelList<global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Element>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.ElementBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.ElementBuilder>)),
					() => global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.Element_Elements);
		}
	}
}

namespace DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Internal
{
	
	internal class DeclarationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new DeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new DeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class DeclarationImpl : global::MetaDslx.Core.ImmutableSymbolBase, Declaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal DeclarationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Declaration; }
		}
	
		public new DeclarationBuilder ToMutable()
		{
			return (DeclarationBuilder)base.ToMutable();
		}
	
		public new DeclarationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (DeclarationBuilder)base.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, ref name0); }
		}
	}
	
	internal class DeclarationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DeclarationBuilder
	{
	
		internal DeclarationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SeleniumUIImplementationProvider.Implementation.Declaration(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Declaration; }
		}
	
		public new Declaration ToImmutable()
		{
			return (Declaration)base.ToImmutable();
		}
	
		public new Declaration ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Declaration)base.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
	}
	
	internal class NamespaceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Namespace.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new NamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new NamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamespaceImpl : global::MetaDslx.Core.ImmutableSymbolBase, Namespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Declaration> declarations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal NamespaceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Namespace; }
		}
	
		public new NamespaceBuilder ToMutable()
		{
			return (NamespaceBuilder)base.ToMutable();
		}
	
		public new NamespaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (NamespaceBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, ref name0); }
		}
	}
	
	internal class NamespaceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, NamespaceBuilder
	{
		private global::MetaDslx.Core.MutableModelList<DeclarationBuilder> declarations0;
	
		internal NamespaceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SeleniumUIImplementationProvider.Implementation.Namespace(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Namespace; }
		}
	
		public new Namespace ToImmutable()
		{
			return (Namespace)base.ToImmutable();
		}
	
		public new Namespace ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Namespace)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
	}
	
	internal class TagId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Tag.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new TagImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new TagBuilderImpl(this, model, creating);
		}
	}
	
	internal class TagImpl : global::MetaDslx.Core.ImmutableSymbolBase, Tag
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string typeName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal TagImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Tag; }
		}
	
		public new TagBuilder ToMutable()
		{
			return (TagBuilder)base.ToMutable();
		}
	
		public new TagBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (TagBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string TypeName
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Tag.TypeNameProperty, ref typeName0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, ref name0); }
		}
	}
	
	internal class TagBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TagBuilder
	{
	
		internal TagBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SeleniumUIImplementationProvider.Implementation.Tag(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Tag; }
		}
	
		public new Tag ToImmutable()
		{
			return (Tag)base.ToImmutable();
		}
	
		public new Tag ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Tag)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string TypeName
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Tag.TypeNameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Tag.TypeNameProperty, value); }
		}
		
		public Func<string> TypeNameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Tag.TypeNameProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Tag.TypeNameProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
	}
	
	internal class PageId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Page.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new PageImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new PageBuilderImpl(this, model, creating);
		}
	}
	
	internal class PageImpl : global::MetaDslx.Core.ImmutableSymbolBase, Page
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string locator0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Tag tag0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Element parent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Element> elements0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal PageImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Page; }
		}
	
		public new PageBuilder ToMutable()
		{
			return (PageBuilder)base.ToMutable();
		}
	
		public new PageBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (PageBuilder)base.ToMutable(model);
		}
	
		ElementBuilder Element.ToMutable()
		{
			return this.ToMutable();
		}
	
		ElementBuilder Element.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Locator
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty, ref locator0); }
		}
	
		
		public Tag Tag
		{
		    get { return this.GetReference<Tag>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty, ref tag0); }
		}
	
		
		public Element Parent
		{
		    get { return this.GetReference<Element>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty, ref parent0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Element> Elements
		{
		    get { return this.GetList<Element>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ElementsProperty, ref elements0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, ref name0); }
		}
	}
	
	internal class PageBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, PageBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ElementBuilder> elements0;
	
		internal PageBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SeleniumUIImplementationProvider.Implementation.Page(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Page; }
		}
	
		public new Page ToImmutable()
		{
			return (Page)base.ToImmutable();
		}
	
		public new Page ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Page)base.ToImmutable(model);
		}
	
		Element ElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Element ElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Locator
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty, value); }
		}
		
		public Func<string> LocatorLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Element.LocatorProperty, value); }
		}
	
		
		public TagBuilder Tag
		{
			get { return this.GetReference<TagBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty); }
			set { this.SetReference<TagBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty, value); }
		}
		
		public Func<TagBuilder> TagLazy
		{
			get { return this.GetLazyReference<TagBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Element.TagProperty, value); }
		}
	
		
		public ElementBuilder Parent
		{
			get { return this.GetReference<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty); }
			set { this.SetReference<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty, value); }
		}
		
		public Func<ElementBuilder> ParentLazy
		{
			get { return this.GetLazyReference<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Element.ParentProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ElementBuilder> Elements
		{
			get { return this.GetList<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ElementsProperty, ref elements0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
	}
	
	internal class ElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, Element
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string locator0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Tag tag0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Element parent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Element> elements0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal ElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Element; }
		}
	
		public new ElementBuilder ToMutable()
		{
			return (ElementBuilder)base.ToMutable();
		}
	
		public new ElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ElementBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Locator
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty, ref locator0); }
		}
	
		
		public Tag Tag
		{
		    get { return this.GetReference<Tag>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty, ref tag0); }
		}
	
		
		public Element Parent
		{
		    get { return this.GetReference<Element>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty, ref parent0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Element> Elements
		{
		    get { return this.GetList<Element>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ElementsProperty, ref elements0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, ref name0); }
		}
	}
	
	internal class ElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ElementBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ElementBuilder> elements0;
	
		internal ElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SeleniumUIImplementationProvider.Implementation.Element(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SeleniumUIInstance.Element; }
		}
	
		public new Element ToImmutable()
		{
			return (Element)base.ToImmutable();
		}
	
		public new Element ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Element)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Locator
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty, value); }
		}
		
		public Func<string> LocatorLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.LocatorProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Element.LocatorProperty, value); }
		}
	
		
		public TagBuilder Tag
		{
			get { return this.GetReference<TagBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty); }
			set { this.SetReference<TagBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty, value); }
		}
		
		public Func<TagBuilder> TagLazy
		{
			get { return this.GetLazyReference<TagBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.TagProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Element.TagProperty, value); }
		}
	
		
		public ElementBuilder Parent
		{
			get { return this.GetReference<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty); }
			set { this.SetReference<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty, value); }
		}
		
		public Func<ElementBuilder> ParentLazy
		{
			get { return this.GetLazyReference<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ParentProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Element.ParentProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ElementBuilder> Elements
		{
			get { return this.GetList<ElementBuilder>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Element.ElementsProperty, ref elements0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.SeleniumUIDescriptor.Declaration.NameProperty); }
			set { this.SetLazyReference(SeleniumUIDescriptor.Declaration.NameProperty, value); }
		}
	}

	internal class SeleniumUIBuilderInstance
	{
		internal static SeleniumUIBuilderInstance instance = new SeleniumUIBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder MetaModel;
		internal global::MetaDslx.Core.MutableModel Model;
		internal global::MetaDslx.Core.MutableModelGroup ModelGroup;
	
	
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp4;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder __tmp6;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Declaration;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Declaration_Name;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp11;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Namespace;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp7;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_Declarations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Tag;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Tag_TypeName;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Page;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Element;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp8;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Element_Locator;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Element_Tag;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Element_Parent;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Element_Elements;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp10;
	
		internal SeleniumUIBuilderInstance()
		{
			this.ModelGroup = new global::MetaDslx.Core.MutableModelGroup();
			this.ModelGroup.AddReference(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Model.ToMutable(true));
			this.Model = this.ModelGroup.CreateModel("SeleniumUI");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			SeleniumUIImplementationProvider.Implementation.SeleniumUIBuilderInstance(this);
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
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaNamespace();
			__tmp6 = factory.MetaModel();
			MetaModel = __tmp6;
			Declaration = factory.MetaClass();
			Declaration_Name = factory.MetaProperty();
			__tmp11 = factory.MetaAnnotation();
			Namespace = factory.MetaClass();
			__tmp7 = factory.MetaAnnotation();
			Namespace_Declarations = factory.MetaProperty();
			Tag = factory.MetaClass();
			Tag_TypeName = factory.MetaProperty();
			Page = factory.MetaClass();
			Element = factory.MetaClass();
			__tmp8 = factory.MetaAnnotation();
			Element_Locator = factory.MetaProperty();
			Element_Tag = factory.MetaProperty();
			Element_Parent = factory.MetaProperty();
			Element_Elements = factory.MetaProperty();
			__tmp9 = factory.MetaCollectionType();
			__tmp10 = factory.MetaCollectionType();
	
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
			__tmp3.Name = "Compilers";
			// __tmp3.MetaModel = null;
			__tmp3.Declarations.AddLazy(() => __tmp4);
			// __tmp4.MetaModel = null;
			__tmp4.NamespaceLazy = () => __tmp3;
			__tmp4.Documentation = null;
			__tmp4.Name = "SeleniumUI";
			// __tmp4.MetaModel = null;
			__tmp4.Declarations.AddLazy(() => __tmp5);
			// __tmp5.MetaModel = null;
			__tmp5.NamespaceLazy = () => __tmp4;
			__tmp5.Documentation = null;
			__tmp5.Name = "Symbols";
			__tmp5.MetaModelLazy = () => __tmp6;
			__tmp5.Declarations.AddLazy(() => Declaration);
			__tmp5.Declarations.AddLazy(() => Namespace);
			__tmp5.Declarations.AddLazy(() => Tag);
			__tmp5.Declarations.AddLazy(() => Page);
			__tmp5.Declarations.AddLazy(() => Element);
			__tmp6.Name = "SeleniumUI";
			__tmp6.Documentation = null;
			__tmp6.Uri = "http://DevToolsX/Documents/SeleniumUI/1.0";
			__tmp6.NamespaceLazy = () => __tmp5;
			Declaration.MetaModelLazy = () => __tmp6;
			Declaration.NamespaceLazy = () => __tmp5;
			Declaration.Documentation = null;
			Declaration.Name = "Declaration";
			Declaration.IsAbstract = true;
			Declaration.Properties.AddLazy(() => Declaration_Name);
			Declaration_Name.Annotations.AddLazy(() => __tmp11);
			Declaration_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Declaration_Name.Name = "Name";
			Declaration_Name.Documentation = null;
			// Declaration_Name.Kind = null;
			Declaration_Name.ClassLazy = () => Declaration;
			__tmp11.Name = "Name";
			__tmp11.Documentation = null;
			Namespace.MetaModelLazy = () => __tmp6;
			Namespace.NamespaceLazy = () => __tmp5;
			Namespace.Documentation = null;
			Namespace.Name = "Namespace";
			Namespace.Annotations.AddLazy(() => __tmp7);
			// Namespace.IsAbstract = null;
			Namespace.SuperClasses.AddLazy(() => Declaration);
			Namespace.Properties.AddLazy(() => Namespace_Declarations);
			__tmp7.Name = "Scope";
			__tmp7.Documentation = null;
			Namespace_Declarations.TypeLazy = () => __tmp9;
			Namespace_Declarations.Name = "Declarations";
			Namespace_Declarations.Documentation = null;
			Namespace_Declarations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Namespace_Declarations.ClassLazy = () => Namespace;
			Tag.MetaModelLazy = () => __tmp6;
			Tag.NamespaceLazy = () => __tmp5;
			Tag.Documentation = null;
			Tag.Name = "Tag";
			// Tag.IsAbstract = null;
			Tag.SuperClasses.AddLazy(() => Declaration);
			Tag.Properties.AddLazy(() => Tag_TypeName);
			Tag_TypeName.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Tag_TypeName.Name = "TypeName";
			Tag_TypeName.Documentation = null;
			// Tag_TypeName.Kind = null;
			Tag_TypeName.ClassLazy = () => Tag;
			Page.MetaModelLazy = () => __tmp6;
			Page.NamespaceLazy = () => __tmp5;
			Page.Documentation = null;
			Page.Name = "Page";
			// Page.IsAbstract = null;
			Page.SuperClasses.AddLazy(() => Element);
			Element.MetaModelLazy = () => __tmp6;
			Element.NamespaceLazy = () => __tmp5;
			Element.Documentation = null;
			Element.Name = "Element";
			Element.Annotations.AddLazy(() => __tmp8);
			// Element.IsAbstract = null;
			Element.SuperClasses.AddLazy(() => Declaration);
			Element.Properties.AddLazy(() => Element_Locator);
			Element.Properties.AddLazy(() => Element_Tag);
			Element.Properties.AddLazy(() => Element_Parent);
			Element.Properties.AddLazy(() => Element_Elements);
			__tmp8.Name = "Scope";
			__tmp8.Documentation = null;
			Element_Locator.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Element_Locator.Name = "Locator";
			Element_Locator.Documentation = null;
			// Element_Locator.Kind = null;
			Element_Locator.ClassLazy = () => Element;
			Element_Tag.TypeLazy = () => Tag;
			Element_Tag.Name = "Tag";
			Element_Tag.Documentation = null;
			// Element_Tag.Kind = null;
			Element_Tag.ClassLazy = () => Element;
			Element_Parent.TypeLazy = () => Element;
			Element_Parent.Name = "Parent";
			Element_Parent.Documentation = null;
			// Element_Parent.Kind = null;
			Element_Parent.ClassLazy = () => Element;
			Element_Parent.OppositeProperties.AddLazy(() => Element_Elements);
			Element_Elements.TypeLazy = () => __tmp10;
			Element_Elements.Name = "Elements";
			Element_Elements.Documentation = null;
			Element_Elements.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Element_Elements.ClassLazy = () => Element;
			Element_Elements.OppositeProperties.AddLazy(() => Element_Parent);
			__tmp9.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp9.InnerTypeLazy = () => Declaration;
			__tmp10.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp10.InnerTypeLazy = () => Element;
	
			foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Internal.SeleniumUIImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class SeleniumUIImplementationBase
	{
		/// <summary>
		/// Implements the constructor: SeleniumUIBuilderInstance()
		/// </summary>
		internal virtual void SeleniumUIBuilderInstance(SeleniumUIBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: Declaration()
		/// </summary>
		public virtual void Declaration(DeclarationBuilder _this)
		{
			this.CallDeclarationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Declaration
		/// </summary>
		protected virtual void CallDeclarationSuperConstructors(DeclarationBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: Namespace()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Namespace(NamespaceBuilder _this)
		{
			this.CallNamespaceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Namespace
		/// </summary>
		protected virtual void CallNamespaceSuperConstructors(NamespaceBuilder _this)
		{
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Tag()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Tag(TagBuilder _this)
		{
			this.CallTagSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Tag
		/// </summary>
		protected virtual void CallTagSuperConstructors(TagBuilder _this)
		{
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Page()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Element</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Page(PageBuilder _this)
		{
			this.CallPageSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Page
		/// </summary>
		protected virtual void CallPageSuperConstructors(PageBuilder _this)
		{
			this.Element(_this);
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Element()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Element(ElementBuilder _this)
		{
			this.CallElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Element
		/// </summary>
		protected virtual void CallElementSuperConstructors(ElementBuilder _this)
		{
			this.Declaration(_this);
		}
	
	}

	internal class SeleniumUIImplementationProvider
	{
		// If there is a compile error at this line, create a new class called SeleniumUIImplementation
		// which is a subclass of global::DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Internal.SeleniumUIImplementationBase:
		private static SeleniumUIImplementation implementation = new SeleniumUIImplementation();
	
		public static SeleniumUIImplementation Implementation
		{
			get { return implementation; }
		}
	}
}
