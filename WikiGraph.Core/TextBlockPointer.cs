namespace WikiGraph.Core
{
    /// <summary>
    /// Represents a pointer to text.
    /// </summary>
    public class TextBlockPointer
    {
        public TextBlockPointer(string hash, int start, int end)
        {
            Hash = hash;
            Start = start;
            End = end;
        }

        public string Hash { get; }
        public int Start { get; }
        public int End { get; }
        public int Length { get => End - Start; }
    }
}
