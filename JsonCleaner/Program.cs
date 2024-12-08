using System.Text.RegularExpressions;
using System.Globalization;

public class JsonEscapeSequenceReplacer
{
    public static string ReplaceUtfEscapeSequences(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return json;
        }

        // Regex to find UTF escape sequences (\uXXXX)
        var utfEscapeSequenceRegex = new Regex(@"\\u(?<Value>[0-9a-fA-F]{4})", RegexOptions.Compiled);

        // Replace each escape sequence
        return utfEscapeSequenceRegex.Replace(json, match =>
        {
            var hexValue = match.Groups["Value"].Value;

            // Parse the hex value
            if (int.TryParse(hexValue, NumberStyles.HexNumber, null, out int unicode))
            {
                // Convert to character
                var character = (char)unicode;

                // If character is ASCII (0x00 to 0x7F), replace; otherwise, keep escape sequence
                return unicode <= 0x7F ? character.ToString() : match.Value;
            }

            // If parsing fails, keep the original escape sequence
            return match.Value;
        });
    }
}

class Program
{
    static void Main()
    {
        string json = @"{ ""example"": ""Hello\u0026World"" }";
        string result = JsonEscapeSequenceReplacer.ReplaceUtfEscapeSequences(json);

        Console.WriteLine("Original JSON: " + json);
        Console.WriteLine("Processed JSON: " + result);
    }
}
