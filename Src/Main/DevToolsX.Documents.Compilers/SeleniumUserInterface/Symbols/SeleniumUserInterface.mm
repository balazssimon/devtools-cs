namespace DevToolsX.Documents.Compilers.Symbols
{
	metamodel SeleniumUserInterfaceModel(Uri="http://devtoolsx.documents.documentmodel/1.0"); 

	class Element
	{
		string Locator;
		string Tag;
		string Name;
		Element Parent;
		list<Element> Children;
	}

	association Element.Parent with Element.Children;
}
