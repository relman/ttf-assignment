using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using TTF.Services;

namespace TTF.Web
{
    public class HomeController : ApiController
    {
        private readonly IMappingService _service;

        public HomeController(IMappingService service)
        {
            _service = service;
        }

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
            var output = _service.Calculate(input);
            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(output));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
    }
}
