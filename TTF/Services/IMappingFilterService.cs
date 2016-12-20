using System;
using System.Collections.Generic;
using TTF.Mappings;

namespace TTF.Services
{
    public interface IMappingFilterService
    {
        IList<IMappingBase> Filter(IList<Type> types, IInput input);
    }
}
