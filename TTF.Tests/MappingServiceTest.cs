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
                .Returns(new List<IMappingBase> { new Mock<IMappingBase>().Object });
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

        //[TestMethod]
        //public void TestCalculate_ActivatorService_Create()
        //{
        //    var input = new Mock<IInput>();
        //    var types = new List<Type> { typeof(BaseMapping1), typeof(SpecialMapping1) };
        //    var listService = new Mock<IMappingListService>(MockBehavior.Strict);
        //    listService
        //        .Setup(s => s.GetList())
        //        .Returns(types);
        //    var baseMapping = new Mock<IMappingBase>(MockBehavior.Strict);
        //    baseMapping
        //        .SetupGet(s => s.IsAcceptable)
        //        .Returns(false);
        //    var activatorService = new Mock<IActivatorService>(MockBehavior.Strict);
        //    activatorService
        //        .Setup(
        //            s =>
        //                s.Create(It.Is<Type>(t => t == typeof(BaseMapping1)),
        //                    It.Is<object[]>(arr => arr.Contains(input.Object))))
        //        .Returns(baseMapping.Object);
        //    var specMapping = new Mock<IMappingBase>(MockBehavior.Strict);
        //    specMapping
        //        .SetupGet(s => s.IsAcceptable)
        //        .Returns(false);
        //    activatorService
        //        .Setup(
        //            s =>
        //                s.Create(It.Is<Type>(t => t == typeof(SpecialMapping1)),
        //                    It.Is<object[]>(arr => arr.Contains(input.Object))))
        //        .Returns(specMapping.Object);
        //    var factory = new Mock<IOutputFactory>();
        //    var output = new Mock<IOutput>();
        //    factory.Setup(s => s.Create())
        //        .Returns(output.Object);

        //    var service = new MappingService(listService.Object, activatorService.Object, factory.Object);
        //    var result = service.Calculate(input.Object);

        //    Assert.AreEqual(output.Object, result);
        //    listService.Verify(v => v.GetList(), Times.Once());
        //    activatorService.Verify(v => v.Create(It.IsAny<Type>(), It.IsAny<object[]>()), Times.Exactly(types.Count));
        //    factory.Verify(v => v.Create(), Times.Once());
        //}
    }
}
