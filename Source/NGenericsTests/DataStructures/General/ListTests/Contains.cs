using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Contains
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int> {3};
            Assert.IsTrue(listBase.Contains(3));
        }
        [Test]
        public void Interface()
        {
            var listBase = new ListBase<int> {3};
            Assert.IsTrue(((IList)listBase).Contains(3));
        }
    }
}