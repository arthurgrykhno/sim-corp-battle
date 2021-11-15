using Microsoft.VisualBasic.FileIO;

namespace SC.DevChallenge.Services.Extensions
{
    public static class TextFieldParserExtensions
    {
        public static void SkipCSVHeaders(this TextFieldParser textFieldParser)
        {
            if (!textFieldParser.EndOfData)
            {
                textFieldParser.ReadLine();
            }
        }
    }
}
