namespace TTF.Mappings
{
    public interface IMappingBase
    {
        Input InData { get; }
        
        string Name { get; }
        
        bool IsAcceptable();
        
        decimal Calc();
    }
}
