using System.Text;

namespace YesNoParser
{
    /// <summary>
    /// Compiles a string that contains everything from a piece of text that comes after a 
    /// "yes character" while excluding everything that comes after a "no character".
    /// Example use case to extract text from a HTML document:
    /// var parser = new YesNoParser('>', '<');
    /// var freeFromHtmlTags = parser.Parse(html);
    /// </summary>
    public class YesNoParser
    {
        private readonly char _yesChar;
        private readonly char _noChar;

        public YesNoParser(char yesChar, char noChar)
        {
            _yesChar = yesChar;
            _noChar = noChar;
        }

        public string Parse(string text)
        {
            var skipChars = false;
            var output = new StringBuilder();
            foreach(var c in text)
            {
                if (c == _noChar)
                {
                    skipChars = true;
                }
                else if (c == _yesChar)
                {
                    skipChars = false;
                }
                else
                {
                    if (!skipChars)
                    {
                        output.Append(c);
                    }
                }
            }
            return output.ToString();
        }
    }
}
