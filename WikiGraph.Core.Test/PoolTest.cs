using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WikiGraph.Core.Test
{
    [TestClass]
    public class PoolTest
    {
        [TestMethod]
        public void StoreATextBlockAndRetrieveIt()
        {
            var pool = new TextBlockPool();
            var tb = new TextBlock("hello my name is simon");
            pool.SaveTextBlock(tb);

            TextBlock retrivedBlock;
            Assert.IsTrue(pool.GetTextBlock(tb.Hash, out retrivedBlock), "Fail to retrieve block by hash");

            Assert.AreEqual("hello my name is simon", retrivedBlock.Text);
        }

        [TestMethod]
        public void TextBlockToTheMiddle()
        {
            var pool = new TextBlockPool();
            var tb = new TextBlock("hello my name is simon");
            pool.SaveTextBlock(tb);

            var tbr = new TextBlockPointer(tb.Hash, 6, 8);
            string text = pool.GetTextByLink(tbr);

            Assert.AreEqual("my", text);
        }
    }
}
