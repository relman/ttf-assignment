namespace TTF.Mappings
{
    public abstract class MappingBase
    {
        protected Input InData { get; private set; }

        protected abstract string Name { get; }

        protected MappingBase(Input inData)
        {
            InData = inData;
        }

        protected abstract bool IsAcceptable();

        protected abstract decimal Calc();
    }
}
