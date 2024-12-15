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


        [Fact]
        public void JsonCleaner_Noclean_Success()
        {
            var json = @"{ ""example"": ""Hello&World"" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"Hello&World\" }", cleaned);
        }

        [Fact]
        public void JsonCleaner_CleansMany_Success()
        {
            var json = @"{ ""example"": ""Hello\u0026\u0026World"" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"Hello&&World\" }", cleaned);
        }
    }
}