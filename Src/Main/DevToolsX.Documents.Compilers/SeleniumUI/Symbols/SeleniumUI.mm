namespace DevToolsX.Documents.Compilers.SeleniumUI.Symbols
{
	metamodel SeleniumUI(Uri="http://DevToolsX/Documents/SeleniumUI/1.0"); 

	abstract class Declaration
	{
		[Name]
		string Name;
	}

	[Scope]
	class Namespace : Declaration
	{
		containment list<Declaration> Declarations;
	}

	abstract class ElementType : Declaration
	{
		string DeclaredHtmlTag;
		string DeclaredLocator;
	}

	class Tag : ElementType
	{
		string TypeName;
	}

	[Scope]
	class Element : ElementType
	{
		[BaseScope]
		Element Base;

		Element Parent;
		containment list<Element> Elements;

		bool IsPage;

		ElementType Tag;
		derived string HtmlTag;
		derived string Locator;
	}

	association Element.Parent with Element.Elements;
}
