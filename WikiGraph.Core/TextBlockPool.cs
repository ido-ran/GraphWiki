using System;
using System.Collections.Generic;

namespace WikiGraph.Core
{
    /// <summary>
    /// Represents an ever growning pool of text addressable by content.
    /// </summary>
    public class TextBlockPool
    {
        private readonly Dictionary<string, TextBlock> pool = new Dictionary<string, TextBlock>();

        public void SaveTextBlock(TextBlock tb)
        {
            if (!pool.ContainsKey(tb.Hash))
            {
                pool[tb.Hash] = tb;
            }
        }

        public bool GetTextBlock(string hash, out TextBlock tb)
        {
            return pool.TryGetValue(hash, out tb);
        }

        public string GetTextByLink(TextBlockPointer tbp)
        {
            if (!GetTextBlock(tbp.Hash, out TextBlock tb))
            {
                return string.Empty;
            }
            else
            {
                return tb.Text.Substring(tbp.Start, tbp.Length);
            }
        }
    }
}
