/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions.DoubleExtensionsTests
{
    [TestFixture]
    public class IsSimilarTo
    {
        [Test]
        public void Should_Be_Similiar()
        {
            var d1 = 5.000000000009d;
            var d2 = 5d;

            Assert.IsTrue(d1.IsSimilarTo(d2));
        }

        [Test]
        public void Should_Not_Be_Similiar()
        {
            var d1 = 5.00000000002d;
            var d2 = 5d;

            Assert.IsFalse(d1.IsSimilarTo(d2));
        }
    }

}

