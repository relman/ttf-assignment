using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TTF.Mappings;
using TTF.Services;

namespace TTF.Tests
{
    [TestClass]
    public class MappingServiceTest
    {
        [TestMethod]
        public void Test_Calculate_InternalServiceCalls()
        {
            var input = new Mock<IInput>();
            var listService = new Mock<IMappingListService>(MockBehavior.Strict);
            listService
                .Setup(s => s.GetList())
                .Returns(new List<Type>());
            var filterService = new Mock<IMappingFilterService>(MockBehavior.Strict);
            filterService
                .Setup(s => s.Filter(It.IsAny<IList<Type>>(), It.IsAny<IInput>()))
                .Returns(new List<IMappingBase>());
            var factory = new Mock<IOutputFactory>();
            var output = new Mock<IOutput>();
            factory.Setup(s => s.Create())
                .Returns(output.Object);

            var service = new MappingService(listService.Object, filterService.Object, factory.Object);
            var result = service.Calculate(input.Object);

            listService.Verify(v => v.GetList(), Times.Once());
            filterService.Verify(v => v.Filter(It.IsAny<IList<Type>>(), It.IsAny<IInput>()), Times.Once());
            factory.Verify(v => v.Create(), Times.Once());
            Assert.AreEqual(output.Object, result);
        }

        [TestMethod]
        public void Test_Calculate_AddOutputItem()
        {
            var input = new Mock<IInput>();
            var listService = new Mock<IMappingListService>(MockBehavior.Strict);
            listService
                .Setup(s => s.GetList())
                .Returns(new List<Type>());
            var filteredMappings = new List<IMappingBase>
            {
                new Mock<IMappingBase>().Object,
                new Mock<IMappingBase>().Object
            };
            var filterService = new Mock<IMappingFilterService>(MockBehavior.Strict);
            filterService
                .Setup(s => s.Filter(It.IsAny<IList<Type>>(), It.IsAny<IInput>()))
                .Returns(filteredMappings);
            var output = new Mock<IOutput>();
            output
                .Setup(s => s.AddOutputItem(It.IsAny<XEnum>(), It.IsAny<decimal>(), It.IsAny<string>()));
            var factory = new Mock<IOutputFactory>();
            factory.Setup(s => s.Create())
                .Returns(output.Object);

            var service = new MappingService(listService.Object, filterService.Object, factory.Object);
            var result = service.Calculate(input.Object);

            listService.Verify(v => v.GetList(), Times.Once());
            filterService.Verify(v => v.Filter(It.IsAny<IList<Type>>(), It.IsAny<IInput>()), Times.Once());
            factory.Verify(v => v.Create(), Times.Once());
            output.Verify(v => v.AddOutputItem(It.IsAny<XEnum>(), It.IsAny<decimal>(), It.IsAny<string>()),
                Times.Exactly(filteredMappings.Count));
            Assert.AreEqual(output.Object, result);
        }
    }
}
