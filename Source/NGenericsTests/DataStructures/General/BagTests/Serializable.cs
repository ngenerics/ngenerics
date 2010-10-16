using NGenerics.DataStructures.General;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Serializable : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag1 = new Bag<int>();
            var bag2 = SerializeUtil.BinarySerializeDeserialize(bag1);

            Assert.AreNotSame(bag1, bag2);
            Assert.IsTrue(bag1.Equals(bag2));
        }

    }
}