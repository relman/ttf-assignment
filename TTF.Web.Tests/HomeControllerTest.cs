using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System.Net.Http.Headers;
using TTF.Services;
using TTF.Web.Controllers;

namespace TTF.Web.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test_Index()
        {
            var service = new Mock<IMappingService>(MockBehavior.Strict);
            var factory = new Mock<IResponseMessageFactory>(MockBehavior.Strict);
            var responseMessage = new Mock<HttpResponseMessage>(MockBehavior.Strict);
            var controller = new HomeController(service.Object, factory.Object);
            factory.Setup(s => s.Create())
                .Returns(responseMessage.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(new MediaTypeHeaderValue("text/html"), result.Content.Headers.ContentType);
            factory.Verify(v => v.Create(), Times.Once);
        }
    }
}
