using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TTF.Services;

namespace TTF.Tests
{
    [TestClass]
    public class MappingServiceTest
    {
        [TestMethod]
        public void TestCalculate_MappingListService_GetList()
        {
            var listService = new Mock<IMappingListService>(MockBehavior.Strict);
            var activatorService = new Mock<IActivatorService>();
            var factory = new Mock<IOutputFactory>();
            var service = new MappingService(listService.Object, activatorService.Object, factory.Object);

            listService.Setup(s => s.GetList())
                .Returns(new List<Type>());
            var output = new Mock<IOutput>();
            factory.Setup(s => s.Create())
                .Returns(output.Object);
            var input = new Mock<IInput>();
            var result = service.Calculate(input.Object);
            Assert.AreEqual(output.Object, result);
            listService.Verify(v => v.GetList(), Times.Once());
        }
    }
}
