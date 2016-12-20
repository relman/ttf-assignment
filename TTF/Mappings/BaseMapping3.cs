namespace TTF.Mappings
{
    public class BaseMapping3 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name { get { return "Base Mapping C"; } }

        /// <summary>
        /// !A && B && C => X = T
        /// </summary>
        public virtual bool IsAcceptable { get { return !InData.A && InData.B && InData.C; } }

        public Output.XEnum X { get { return Output.XEnum.T; } }

        /// <summary>
        /// X = T => Y = D - (D * F / 100)
        /// </summary>
        public decimal Y { get { return InData.D - (InData.D * InData.F / 100); } }

        public BaseMapping3(Input input)
        {
            InData = input;
        }
    }
}
