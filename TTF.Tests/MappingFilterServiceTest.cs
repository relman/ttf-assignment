using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TTF.Mappings;
using TTF.Services;

namespace TTF.Tests
{
    [TestClass]
    public class MappingFilterServiceTest
    {
        [TestMethod]
        public void Test_Filter_Count()
        {
            var types = new List<Type> { typeof(BaseMapping1), typeof(SpecialMapping1) };
            var input = new Mock<IInput>(MockBehavior.Strict);
            var activatorService = new Mock<IActivatorService>(MockBehavior.Strict);
            activatorService
                .Setup(s => s.Create(It.IsAny<Type>(), It.Is<IInput>(i => i == input.Object)))
                .Returns(() =>
                {
                    var mapping = new Mock<IMappingBase>();
                    mapping.Setup(s => s.IsAcceptable)
                        .Returns(true);
                    return mapping.Object;
                });
            var service = new MappingFilterService(activatorService.Object);
            var result = service.Filter(types, input.Object);
            activatorService.Verify(v => v.Create(It.IsAny<Type>(), It.Is<IInput>(i => i == input.Object)),
                Times.Exactly(types.Count));
            Assert.IsNotNull(result);
            Assert.AreEqual(types.Count, result.Count);
        }

        [TestMethod]
        public void Test_Filter_SingleResult()
        {
            var types = new List<Type> { typeof(BaseMapping2), typeof(BaseMapping2), typeof(SpecialMapping2) };
            var input = new Mock<IInput>(MockBehavior.Strict);
            var activatorService = new Mock<IActivatorService>(MockBehavior.Strict);
            activatorService
                .Setup(s => s.Create(It.Is<Type>(t => t == typeof(BaseMapping2)),
                    It.Is<object[]>(args => args.Contains(input.Object))))
                .Returns(() =>
                {
                    var m = new Mock<IMappingBase>();
                    m.Setup(s => s.IsAcceptable)
                        .Returns(true);
                    return m.Object;
                });
            var mapping = new Mock<IMappingBase>();
            mapping.Setup(s => s.IsAcceptable)
                .Returns(true);
            mapping.Setup(s => s.IsOverride)
                .Returns(true);
            activatorService
                .Setup(s => s.Create(It.Is<Type>(t => t == typeof(SpecialMapping2)),
                    It.Is<object[]>(args => args.Contains(input.Object))))
                .Returns(mapping.Object);
            var service = new MappingFilterService(activatorService.Object);
            var result = service.Filter(types, input.Object);
            activatorService.Verify(v => v.Create(It.IsAny<Type>(), It.Is<IInput>(i => i == input.Object)),
                Times.Exactly(types.Count));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(mapping.Object));
        }
    }
}
