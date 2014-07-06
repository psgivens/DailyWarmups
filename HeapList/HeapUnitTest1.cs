using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeapList
{
    [TestClass]
    public class HeapUnitTest1
    {
        [TestMethod]
        public void TestHeapConstruction()
        {
            var array = new int[] { 34, 92, 83, 45, 12, 2, 4, 94 };
            var sorted = new int[] { 2, 34, 4, 92, 45, 83, 12, 94 };
            var heap = new Heap(array);
            var values = heap.Values.ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                Assert.IsTrue(values[i] == sorted[i]);
            }
        }

        [TestMethod]
        public void TestHeapRemoval()
        {
            Assert.Fail("TestHeapRemoval not implemented");
        }
    }
}
