namespace TTF.Mappings
{
    public class BaseMapping2 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name
        {
            get { return "Base Mapping B"; }
        }

        public BaseMapping2(Input input)
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
        /// X = R => Y = D + (D * (E - F) / 100)
        /// </summary>
        public virtual decimal Calc()
        {
            return InData.D + (InData.D * (InData.E - InData.F) / 100);
        }
    }
}
