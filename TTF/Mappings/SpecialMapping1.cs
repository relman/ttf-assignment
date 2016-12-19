namespace TTF.Mappings
{
    public class SpecialMapping1 : MappingBase
    {
        public SpecialMapping1(Input input)
            : base(input)
        {
        }

        protected override string Name
        {
            get { return "Specialized Mapping 1"; }
        }

        /// <summary>
        /// A && B && C => X = R
        /// </summary>
        protected override bool IsAcceptable()
        {
            return InData.A && InData.B && InData.C;
        }

        /// <summary>
        /// X = R => Y = 2D + (D * E / 100)
        /// </summary>
        protected override decimal Calc()
        {
            return 2 * InData.D + (InData.D * InData.E / 100);
        }
    }
}
