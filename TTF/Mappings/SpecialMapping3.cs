namespace TTF.Mappings
{
    public class SpecialMapping3 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name { get { return "Special Mapping 2B"; } }

        /// <summary>
        /// A && !B && C => X = S
        /// </summary>
        public virtual bool IsAcceptable { get { return InData.A && !InData.B && InData.C; } }

        public Output.XEnum X { get { return Output.XEnum.S; } }

        /// <summary>
        /// X = S => Y = F + D + (D * E / 100)
        /// </summary>
        public virtual decimal Y { get { return InData.F + InData.D + (InData.D * InData.E / 100); } }

        public SpecialMapping3(Input input)
        {
            InData = input;
        }
    }
}
