namespace TTF.Mappings
{
    public class SpecialMapping2 : IMappingBase
    {
        public IInput InData { get; private set; }

        public virtual string Name { get { return "Special Mapping 2A"; } }

        /// <summary>
        /// A && B && !C => X = T
        /// </summary>
        public virtual bool IsAcceptable { get { return InData.A && InData.B && !InData.C; } }

        public XEnum X { get { return XEnum.T; } }

        /// <summary>
        /// X = T => Y = D - (D * F / 100)
        /// </summary>
        public virtual decimal Y { get { return InData.D - (InData.D * InData.F / 100.0M); } }

        public bool IsOverride { get { return true; } }

        public SpecialMapping2(IInput input)
        {
            InData = input;
        }
    }
}
