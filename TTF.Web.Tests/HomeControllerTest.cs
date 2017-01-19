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
            factory.Setup(s => s.Create())
                .Returns(responseMessage.Object);
            var controller = new HomeController(service.Object, factory.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(new MediaTypeHeaderValue("text/html"), result.Content.Headers.ContentType);
            factory.Verify(v => v.Create(), Times.Once);
        }

        [TestMethod]
        public void Test_Calc()
        {
            var service = new Mock<IMappingService>(MockBehavior.Strict);
            var input = new Input(false, true, false, 1, 2, 3);
            var output = new Mock<IOutput>(MockBehavior.Strict);
            const string outputJson = "{\"item\":\"value\"}";
            output.Setup(s => s.ToJson())
                .Returns(outputJson);
            service.Setup(s => s.Calculate(It.Is<IInput>(i => i == input)))
                .Returns(output.Object);
            var factory = new Mock<IResponseMessageFactory>(MockBehavior.Strict);
            var responseMessage = new Mock<HttpResponseMessage>(MockBehavior.Strict);
            factory.Setup(s => s.Create())
                .Returns(responseMessage.Object);
            var controller = new HomeController(service.Object, factory.Object);
            var result = controller.Calc(input);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(new MediaTypeHeaderValue("application/json"), result.Content.Headers.ContentType);
            service.Verify(v => v.Calculate(It.Is<IInput>(i => i == input)), Times.Once);
            factory.Verify(v => v.Create(), Times.Once);
            output.Verify(v => v.ToJson(), Times.Once);
        }
    }
}
