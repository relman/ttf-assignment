namespace TTF.Mappings
{
    public interface IMappingBase
    {
        /// <summary>
        /// Input Data
        /// </summary>
        Input InData { get; }

        /// <summary>
        /// Mapping Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Mapping Condition
        /// </summary>
        bool IsAcceptable { get; }

        /// <summary>
        /// Mapping Output X
        /// </summary>
        XEnum X { get; }

        /// <summary>
        /// Mapping Output Y
        /// </summary>
        decimal Y { get; }

        /// <summary>
        /// True - override, False - extend
        /// </summary>
        bool IsOverride { get; }
    }
}
