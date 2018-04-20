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

	class Tag : Declaration
	{
		string TypeName;
	}

	class Page : Element
	{
	}

	[Scope]
	class Element : Declaration
	{
		string Locator;
		Tag Tag;
		Element Parent;
		containment list<Element> Elements;
	}

	association Element.Parent with Element.Elements;
}
