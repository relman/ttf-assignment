namespace TTF.Mappings
{
    public class SpecialMapping1 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name { get { return "Specialized Mapping 1"; } }

        /// <summary>
        /// A && B && C => X = R
        /// </summary>
        public virtual bool IsAcceptable { get { return InData.A && InData.B && InData.C; } }

        public XEnum X { get { return XEnum.R; } }

        /// <summary>
        /// X = R => Y = 2D + (D * E / 100)
        /// </summary>
        public virtual decimal Y { get { return 2 * InData.D + (InData.D * InData.E / 100); } }

        public bool IsOverride { get { return false; } }

        public SpecialMapping1(Input input)
        {
            InData = input;
        }
    }
}
