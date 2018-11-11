using System;
using System.Collections.Generic;
using System.Text;

namespace WikiGraph.Core
{
    public class EDL
    {
        private List<TextBlockPointer> pointers = new List<TextBlockPointer>();

        public void Add(TextBlock tb)
        {
            pointers.Add(new TextBlockPointer(tb.Hash, 0, tb.Text.Length));
        }

        public string GetText(TextBlockPool pool)
        {
            var sb = new StringBuilder();
            foreach (TextBlockPointer tbp in pointers)
            {
                sb.Append(pool.GetTextByLink(tbp));
            }

            return sb.ToString();
        }
    }
}
