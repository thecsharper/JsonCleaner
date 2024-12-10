namespace JsonCleaner.Tests
{
    public class JsonCleanerTests
    {
        [Fact]
        public void Test1()
        {
            var json = @"{ ""example"": ""Hello\u0026World"" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"Hello&World\" }", cleaned);
        }
    }
}