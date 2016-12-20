using System.Collections.Generic;
using TTF.Mappings;

namespace TTF.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMappingListService _listService;
        private readonly IActivatorService _activatorService;

        public MappingService(IMappingListService listService, IActivatorService activatorService)
        {
            _listService = listService;
            _activatorService = activatorService;
        }

        public Output Calculate(Input input)
        {
            var list = new List<IMappingBase>();
            foreach (var type in _listService.GetList())
            {
                var mapping = (IMappingBase)_activatorService.Create(type, input);
                if (mapping.IsAcceptable)
                {
                    list.Add(mapping);
                }
            }

            var result = new Output();
            foreach (var mapping in list)
            {
                result.Items.Add(new Output.OutputItem(mapping.X, mapping.Y, mapping.Name));
            }
            return result;
        }
    }
}
