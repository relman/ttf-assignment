using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var controller = new HomeController(service.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
        }
    }
}
