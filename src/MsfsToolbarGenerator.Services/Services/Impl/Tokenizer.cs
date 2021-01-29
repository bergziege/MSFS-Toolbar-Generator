namespace MsfsToolbarGenerator.Services.Services.Impl {
    public class Tokenizer : ITokenizer {
        public string Replace(string text, string tokenValue) {
            text = text.Replace("#template#", tokenValue.ToLower());
            text = text.Replace("#Template#", tokenValue);
            text = text.Replace("#TEMPLATE#", tokenValue.ToUpper());
            return text;
        }
    }
}