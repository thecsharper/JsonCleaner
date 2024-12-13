namespace JsonCleaner.Tests
{
    public class JsonCleanerTests
    {
        [Fact]
        public void JsonCleaner_Cleans_Success()
        {
            var json = @"{ ""example"": ""Hello\u0026World"" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"Hello&World\" }", cleaned);
        }
    }
}