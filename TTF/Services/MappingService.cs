using System;
using System.Collections.Generic;
using TTF.Mappings;

namespace TTF.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMappingListService _listService;

        public MappingService(IMappingListService listService)
        {
            _listService = listService;
        }

        public Output Calculate(Input input)
        {
            var list = new List<IMappingBase>();
            foreach (var type in _listService.GetList())
            {
                var mapping = (IMappingBase)Activator.CreateInstance(type, input);
                if (mapping.IsAcceptable())
                {
                    list.Add(mapping);
                }
            }

            var result = new Output();
            foreach (var mappingBase in list)
            {
                result.Items.Add(new Output.OutputItem { MappingName = mappingBase.Name, Result = mappingBase.Calc() });
            }
            return result;
        }
    }
}