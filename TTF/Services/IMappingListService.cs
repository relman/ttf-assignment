using System;
using System.Collections.Generic;

namespace TTF.Services
{
    public interface IMappingListService
    {
        IList<Type> GetList();
    }
}
