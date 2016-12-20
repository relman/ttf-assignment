using System.Collections.Generic;

namespace TTF
{
    public enum XEnum
    {
        Error = 0,
        S,
        R,
        T
    }

    public interface IOutput
    {
        void AddOutputItem(XEnum x, decimal y, string mappingName);
    }

    public interface IOutputItem
    {
        XEnum X { get; }

        decimal Y { get; }

        string MappingName { get; }
    }

    public class Output : IOutput
    {
        public List<IOutputItem> Items { get; private set; }

        public bool OK { get { return Items != null && 0 < Items.Count; } }

        public Output()
        {
            Items = new List<IOutputItem>();
        }

        public void AddOutputItem(XEnum x, decimal y, string mappingName)
        {
            Items.Add(new OutputItem(x, y, mappingName));
        }

        public class OutputItem : IOutputItem
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
    }
}
