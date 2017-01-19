using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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

        [TestMethod]
        public void Test_ToJson_EmptyItems()
        {
            var result = new Output();
            Assert.IsNotNull(result);

            var json = result.ToJson();
            Assert.IsNotNull(json);

            var deserializedOutput = JsonConvert.DeserializeObject<Output>(json);
            Assert.IsNotNull(deserializedOutput);
            Assert.IsFalse(deserializedOutput.OK);
        }
    }
}
