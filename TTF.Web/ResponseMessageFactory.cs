using System.Net.Http;

namespace TTF.Web
{
    public class ResponseMessageFactory : IResponseMessageFactory
    {
        public HttpResponseMessage Create()
        {
            return new HttpResponseMessage();
        }
    }
}
