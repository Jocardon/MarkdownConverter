using MarkdownConverter;

namespace MarkdownConverterTests
{
    public class MardownConverterTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Converter_HashtagsAtStartOfLine_ShouldEncapsulateStringWithHtmlHeaderTags(int headingLevel)
        {
            string input = $"{new String('#', headingLevel)}heading";
            var converter = new Converter();

            var result = converter.Convert(input);

            Assert.Equal($"<h{headingLevel}>heading</h{headingLevel}>", result);
            
        }

        [Fact]
        public void SevenOrMoreHashtagsAtStartOfLine_ShouldReturnMaximumOfHeadingLevelSix()
        {
            string input = "#######heading";
            var converter = new Converter();

            var result = converter.Convert(input);

            Assert.Equal("<h6>#heading</h6>", result);
        }


        /*
         convert ###### to <h1>...</h1>, <h2>...</h2>, etc. (happy and sad paths)
         convert italic to <em>...</em> (happy and sad paths)
         convert bold to <strong>...</strong> (happy and sad paths)
         convert italic and bold to <strong><em>...</em></strong> (happy and sad paths)
         convert paragraphs to <p>...</p> (happy and sad paths)
         convert page breaks to <br> (happy and sad paths)
         convert ordered lists to <ol><li>...</li></ol> (happy and sad paths)
         convert unordered lists to <ul><li>...</li></ul> (happy and sad paths)
         */
    }
}
