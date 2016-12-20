using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

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
    }
}
