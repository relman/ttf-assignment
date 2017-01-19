using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TTF.Tests
{
    [TestClass]
    public class OutputTest
    {
        [TestMethod]
        public void Test_Ctor()
        {
            var result = new Output();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.AreEqual(0, result.Items.Count);
        }

        [TestMethod]
        public void Test_AddOutputItem()
        {
            var result = new Output();
            Assert.IsNotNull(result);

            result.AddOutputItem(XEnum.S, 10m, "new mapping");
            Assert.IsNotNull(result.Items);
            Assert.AreEqual(1, result.Items.Count);
        }
    }
}
