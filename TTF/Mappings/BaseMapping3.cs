namespace TTF.Mappings
{
    public class BaseMapping3 : MappingBase
    {
        public BaseMapping3(Input input)
            : base(input)
        {
        }

        protected override string Name
        {
            get { return "Base Mapping 3"; }
        }

        /// <summary>
        /// !A && B && C => X = T
        /// </summary>
        protected override bool IsAcceptable()
        {
            return !InData.A && InData.B && InData.C;
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
