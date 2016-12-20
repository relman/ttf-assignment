namespace TTF.Mappings
{
    public interface IMappingBase
    {
        Input InData { get; }

        string Name { get; }

        bool IsAcceptable { get; }

        Output.XEnum X { get; }

        decimal Y { get; }
    }
}
