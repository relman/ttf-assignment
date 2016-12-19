namespace TTF.Mappings
{
    public class BaseMapping2 : MappingBase
    {
        public BaseMapping2(Input input)
            : base(input)
        {
        }

        /// <summary>
        /// A && B && C => X = R
        /// </summary>
        protected override bool IsAcceptable()
        {
            return InData.A && InData.B && InData.C;
        }

        /// <summary>
        /// X = R => Y = D + (D * (E - F) / 100)
        /// </summary>
        protected override decimal Calc()
        {
            return InData.D + (InData.D * (InData.E - InData.F) / 100);
        }
    }
}
