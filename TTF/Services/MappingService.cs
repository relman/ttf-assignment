namespace TTF.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMappingListService _listService;
        private readonly IMappingFilterService _filterService;
        private readonly IOutputFactory _factory;

        public MappingService(IMappingListService listService, IMappingFilterService filterService, IOutputFactory factory)
        {
            _listService = listService;
            _filterService = filterService;
            _factory = factory;
        }

        public IOutput Calculate(IInput input)
        {
            var types = _listService.GetList();
            var mappings = _filterService.Filter(types, input);

            var result = _factory.Create();
            foreach (var m in mappings)
            {
                result.AddOutputItem(m.X, m.Y, m.Name);
            }
            return result;
        }
    }
}
