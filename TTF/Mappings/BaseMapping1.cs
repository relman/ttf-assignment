namespace TTF.Mappings
{
    public class BaseMapping1 : IMappingBase
    {
        public Input InData { get; private set; }

        public virtual string Name
        {
            get { return "Base Mapping A"; }
        }

        public BaseMapping1(Input input)
        {
            InData = input;
        }

        /// <summary>
        /// A && B && !C => X = S
        /// </summary>
        public virtual bool IsAcceptable()
        {
            return InData.A && InData.B && !InData.C;
        }

        /// <summary>
        /// X = S => Y = D + (D * E / 100)
        /// </summary>
        public virtual decimal Calc()
        {
            return InData.D + (InData.D * InData.E / 100);
        }
    }
}
