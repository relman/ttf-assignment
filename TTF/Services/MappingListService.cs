using System;
using System.Collections.Generic;
using TTF.Mappings;

namespace TTF.Services
{
    public class MappingListService : IMappingListService
    {
        public List<Type> GetList()
        {
            return new List<Type>
            {
                typeof(BaseMapping1), typeof(BaseMapping2), typeof(BaseMapping3), 
                typeof(SpecialMapping1), typeof(SpecialMapping2), typeof(SpecialMapping3)
            };
        }
    }
}