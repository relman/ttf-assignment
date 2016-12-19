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
            public decimal Result { get; set; }

            public string MappingName { get; set; }
        }
    }
}
