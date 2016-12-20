using System.Collections.Generic;

namespace TTF
{
    public class Output
    {
        public List<OutputItem> Items { get; private set; }

        public bool OK { get { return Items != null && 0 < Items.Count; } }

        public Output()
        {
            Items = new List<OutputItem>();
        }

        public class OutputItem
        {
            public XEnum X { get; private set; }

            public decimal Y { get; private set; }

            public string MappingName { get; private set; }

            public OutputItem(XEnum x, decimal y, string mappingName)
            {
                X = x;
                Y = y;
                MappingName = mappingName;
            }
        }

        public enum XEnum
        {
            S,
            R,
            T
        }
    }
}
