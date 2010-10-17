using System.Collections.Generic;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class GetHashcode
    {

        [Test]
        public void Simple()
        {
            var d = new Dictionary<Matrix, string>();

            for (var i = 0; i < 10; i++)
            {
                var test = MatrixTest.GetTestMatrix();
                Assert.IsFalse(d.ContainsKey(test));
                d.Add(test, null);
            }
        }

    }
}