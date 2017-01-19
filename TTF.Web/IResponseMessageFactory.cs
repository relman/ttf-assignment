using System.Net.Http;

namespace TTF.Web
{
    public interface IResponseMessageFactory
    {
        HttpResponseMessage Create();
    }
}
