using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Remove
    {

        [Test]
        public void Interface()
        {
            ICollection<int> c = new CircularQueue<int>(20);
            Assert.IsFalse(c.Remove(5));

            c.Add(2);

            Assert.AreEqual(c.Count, 1);
            Assert.IsTrue(c.Remove(2));
            Assert.AreEqual(c.Count, 0);

            c.Add(4);
            c.Add(5);
            c.Add(6);

            Assert.AreEqual(c.Count, 3);
            Assert.IsFalse(c.Remove(2));
            Assert.AreEqual(c.Count, 3);

            Assert.IsTrue(c.Remove(5));
            Assert.AreEqual(c.Count, 2);

            Assert.IsTrue(c.Remove(6));
            Assert.AreEqual(c.Count, 1);

            Assert.IsTrue(c.Remove(4));
            Assert.AreEqual(c.Count, 0);
        }
	
    }
}