namespace TTF.Mappings
{
    public class SpecialMapping2 : MappingBase
    {
        public SpecialMapping2(Input input)
            : base(input)
        {
        }

        protected override string Name
        {
            get { return "Special Mapping 2A"; }
        }

        /// <summary>
        /// A && B && !C => X = T
        /// </summary>
        protected override bool IsAcceptable()
        {
            return InData.A && InData.B && !InData.C;
        }

        /// <summary>
        /// X = T => Y = D - (D * F / 100)
        /// </summary>
        protected override decimal Calc()
        {
            return InData.D - (InData.D * InData.F / 100);
        }
    }
}
