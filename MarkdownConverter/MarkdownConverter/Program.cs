using MarkdownConverter;

var converter = new Converter();
string input = "### heading level 3";

Console.WriteLine(converter.Convert(input));
Console.ReadLine();