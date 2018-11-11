using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiGraph.Core.Test
{
    [TestClass]
    public class EDLTest
    {
        [TestMethod]
        public void CreateEDL()
        {
            var pool = new TextBlockPool();
            TextBlock helloMyName = new TextBlock("hello my name");
            pool.SaveTextBlock(helloMyName);
            TextBlock isSimon = new TextBlock(" is simon");
            pool.SaveTextBlock(isSimon);

            var edl = new EDL();
            edl.Add(helloMyName);
            edl.Add(isSimon);

            Assert.AreEqual("hello my name is simon", edl.GetText(pool));
        }
    }
}
