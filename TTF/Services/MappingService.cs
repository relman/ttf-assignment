﻿using System.Collections.Generic;
using TTF.Mappings;

namespace TTF.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMappingListService _listService;
        private readonly IActivatorService _activatorService;
        private readonly IOutputFactory _factory;

        public MappingService(IMappingListService listService, IActivatorService activatorService, IOutputFactory factory)
        {
            _listService = listService;
            _activatorService = activatorService;
            _factory = factory;
        }

        public IOutput Calculate(IInput input)
        {
            var list = new List<IMappingBase>();
            foreach (var type in _listService.GetList())
            {
                var mapping = (IMappingBase)_activatorService.Create(type, input);
                if (mapping.IsAcceptable)
                {
                    if (mapping.IsOverride)
                        list.Clear();
                    list.Add(mapping);
                }
            }

            var result = _factory.Create();
            foreach (var mapping in list)
            {
                result.AddOutputItem(mapping.X, mapping.Y, mapping.Name);
            }
            return result;
        }
    }
}
