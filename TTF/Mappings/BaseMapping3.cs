namespace TTF.Mappings
{
    public class BaseMapping3 : IMappingBase
    {
        public IInput InData { get; private set; }

        public virtual string Name { get { return "Base Mapping C"; } }

        /// <summary>
        /// !A && B && C => X = T
        /// </summary>
        public virtual bool IsAcceptable { get { return !InData.A && InData.B && InData.C; } }

        public XEnum X { get { return XEnum.T; } }

        /// <summary>
        /// X = T => Y = D - (D * F / 100)
        /// </summary>
        public decimal Y { get { return InData.D - (InData.D * InData.F / 100.0M); } }

        public bool IsOverride { get { return false; } }

        public BaseMapping3(IInput input)
        {
            InData = input;
        }
    }
}
