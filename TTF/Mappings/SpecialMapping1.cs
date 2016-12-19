namespace TTF.Mappings
{
    public class SpecialMapping1 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name
        {
            get { return "Specialized Mapping 1"; }
        }

        public SpecialMapping1(Input input)
        {
            InData = input;
        }

        /// <summary>
        /// A && B && C => X = R
        /// </summary>
        public virtual bool IsAcceptable()
        {
            return InData.A && InData.B && InData.C;
        }

        /// <summary>
        /// X = R => Y = 2D + (D * E / 100)
        /// </summary>
        public virtual decimal Calc()
        {
            return 2 * InData.D + (InData.D * InData.E / 100);
        }
    }
}
