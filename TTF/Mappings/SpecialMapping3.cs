namespace TTF.Mappings
{
    public class SpecialMapping3 : MappingBase
    {
        public SpecialMapping3(Input input)
            : base(input)
        {
        }

        protected override string Name
        {
            get { return "Special Mapping 2B"; }
        }

        /// <summary>
        /// A && !B && C => X = S
        /// </summary>
        protected override bool IsAcceptable()
        {
            return InData.A && !InData.B && InData.C;
        }

        /// <summary>
        /// X = S => Y = F + D + (D * E / 100)
        /// </summary>
        protected override decimal Calc()
        {
            return InData.F + InData.D + (InData.D * InData.E / 100);
        }
    }
}
