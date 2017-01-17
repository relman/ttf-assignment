namespace TTF.Mappings
{
    public class SpecialMapping3 : IMappingBase
    {
        public IInput InData { get; private set; }

        public virtual string Name { get { return "Special Mapping 2B"; } }

        /// <summary>
        /// A && !B && C => X = S
        /// </summary>
        public virtual bool IsAcceptable { get { return InData.A && !InData.B && InData.C; } }

        public XEnum X { get { return XEnum.S; } }

        /// <summary>
        /// X = S => Y = F + D + (D * E / 100)
        /// </summary>
        public virtual decimal Y { get { return InData.F + InData.D + (InData.D * InData.E / 100.0M); } }

        public bool IsOverride { get { return false; } }

        public SpecialMapping3(IInput input)
        {
            InData = input;
        }
    }
}
