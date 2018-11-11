using System;
using System.Security.Cryptography;

namespace WikiGraph.Core
{
    /// <summary>
    /// Represent a block of text identified by content address.
    /// </summary>
    public class TextBlock
    {
        public TextBlock(string text)
        {
            Hash = GetStringSha256Hash(text);
            Text = text;
        }

        public string Hash { get; }
        public string Text { get; }

        internal static string GetStringSha256Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            using (var sha = new SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
