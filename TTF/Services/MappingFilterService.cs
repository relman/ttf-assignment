using System;
using System.Collections.Generic;
using TTF.Mappings;

namespace TTF.Services
{
    public class MappingFilterService : IMappingFilterService
    {
        private readonly IActivatorService _activatorService;

        public MappingFilterService(IActivatorService activatorService)
        {
            _activatorService = activatorService;
        }

        public IList<IMappingBase> Filter(IList<Type> types, IInput input)
        {
            var list = new List<IMappingBase>();
            foreach (var type in types)
            {
                var mapping = (IMappingBase)_activatorService.Create(type, input);
                if (mapping.IsAcceptable)
                {
                    if (mapping.IsOverride)
                        list.Clear();
                    list.Add(mapping);
                }
            }
            return list;
        }
    }
}
