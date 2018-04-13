# YesNoParser
Compiles a string by extracting everything from a piece of text that comes after a "yes character" while excluding everything that comes after a "no character".

## Example use case to extract text from a HTML document
	var parser = new YesNoParser('>', '<');
	var freeFromHtmlTags = parser.Parse(html);

## CLI example (HTML docs only)

	c:\yesnoparser>YesNoParser.Cli.exe http://mysite.com/resource.htm

Writes a HTML-tagfree string to 
	c:\yesnoparser\http---mysite.com-resource.htm.txt