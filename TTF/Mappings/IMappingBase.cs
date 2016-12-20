namespace TTF.Mappings
{
    public interface IMappingBase
    {
        Input InData { get; }

        string Name { get; }

        bool IsAcceptable { get; }

        XEnum X { get; }

        decimal Y { get; }
    }
}
