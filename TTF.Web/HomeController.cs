using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using TTF.Services;

namespace TTF.Web
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("~/")]
        public HttpResponseMessage Index()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("Service Started. You can POST data");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        [HttpPost]
        [Route("~/")]
        public HttpResponseMessage Calc(Input input)
        {
            var listService = new MappingListService();
            var activatorService = new ActivatorService();
            var filterService = new MappingFilterService(activatorService);
            var factory = new OutputFactory();
            var service = new MappingService(listService, filterService, factory);
            var output = service.Calculate(input);
            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(output));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
    }
}
