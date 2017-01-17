namespace TTF.Mappings
{
    public class BaseMapping2 : IMappingBase
    {
        public IInput InData { get; private set; }

        public virtual string Name { get { return "Base Mapping B"; } }

        /// <summary>
        /// A && B && C => X = R
        /// </summary>
        public virtual bool IsAcceptable { get { return InData.A && InData.B && InData.C; } }

        public XEnum X { get { return XEnum.R; } }

        /// <summary>
        /// X = R => Y = D + (D * (E - F) / 100)
        /// </summary>
        public decimal Y { get { return InData.D + (InData.D * (InData.E - InData.F) / 100.0M); } }

        public bool IsOverride { get { return false; } }

        public BaseMapping2(IInput input)
        {
            InData = input;
        }
    }
}
