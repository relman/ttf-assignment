namespace TTF.Mappings
{
    public class SpecialMapping3 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name
        {
            get { return "Special Mapping 2B"; }
        }

        public SpecialMapping3(Input input)
        {
            InData = input;
        }

        /// <summary>
        /// A && !B && C => X = S
        /// </summary>
        public virtual bool IsAcceptable()
        {
            return InData.A && !InData.B && InData.C;
        }

        /// <summary>
        /// X = S => Y = F + D + (D * E / 100)
        /// </summary>
        public virtual decimal Calc()
        {
            return InData.F + InData.D + (InData.D * InData.E / 100);
        }
    }
}
