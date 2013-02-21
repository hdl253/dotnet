using System.Text;

namespace Papa.Common
{
    public static class StringExtensions
    {
        public static string RemoveChar(this string text, char character)
        {
            string[] parts = text.Split(character);
            var sb = new StringBuilder();
            foreach (var part in parts)
            {
                sb.Append(part);
            }
            return sb.ToString();
        }
    }
}