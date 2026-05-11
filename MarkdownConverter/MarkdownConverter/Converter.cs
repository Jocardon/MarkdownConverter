using System.Text;

namespace MarkdownConverter
{
    public class Converter
    {
        public string Convert(string markdown)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = markdown.Split("\n");
            foreach (var line in lines)
            {
                if (line.StartsWith("#"))
                {
                    int level = int.Min(line.TakeWhile(c => c == '#').Count(), 6);
                    string text = line.Substring(level);
                    sb.Append(CreateHeading(text, level));
                }
            }

            return sb.ToString();
        }

        public string CreateHeading(string text, int level)
        {
            return $"<h{level}>{text}</h{level}>";
        }


    }
}
