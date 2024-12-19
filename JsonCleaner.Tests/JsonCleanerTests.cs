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

        [Fact]
        public void JsonCleaner_CleansAll_Success()
        {
            var json = @"{ ""example"": ""\u0026\u0026"" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"&&\" }", cleaned);
        }

        [Fact]
        public void JsonCleaner_CleansNone_Success()
        {
            var json = @"{ ""example"": """" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"\" }", cleaned);
        }

        [Fact]
        public void JsonCleaner_CleansMixed_Success()
        {
            var json = @"{ ""example"": ""\u0026&"" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"&&\" }", cleaned);
        }

        [Fact]
        public void JsonCleaner_CleansManyMixed_Success()
        {
            var json = @"{ ""example"": ""\u0026&\u0026&"" }";

            var cleaned = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

            Assert.Equal("{ \"example\": \"&&&&\" }", cleaned);
        }
    }
}