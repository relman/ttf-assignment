namespace TTF.Mappings
{
    public class BaseMapping3 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name
        {
            get { return "Base Mapping C"; }
        }

        public BaseMapping3(Input input)
        {
            InData = input;
        }

        /// <summary>
        /// !A && B && C => X = T
        /// </summary>
        public virtual bool IsAcceptable()
        {
            return !InData.A && InData.B && InData.C;
        }

        /// <summary>
        /// X = T => Y = D - (D * F / 100)
        /// </summary>
        public virtual decimal Calc()
        {
            return InData.D - (InData.D * InData.F / 100);
        }
    }
}
