namespace TTF.Mappings
{
    public class BaseMapping1 : MappingBase
    {
        public BaseMapping1(Input input)
            : base(input)
        {
        }

        protected override string Name
        {
            get { return "Base Mapping 1"; }
        }

        /// <summary>
        /// A && B && !C => X = S
        /// </summary>
        protected override bool IsAcceptable()
        {
            return InData.A && InData.B && !InData.C;
        }

        /// <summary>
        /// X = S => Y = D + (D * E / 100)
        /// </summary>
        protected override decimal Calc()
        {
            return InData.D + (InData.D * InData.E / 100);
        }
    }
}
