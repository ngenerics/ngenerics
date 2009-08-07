/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using NUnit.Framework;
using NGenerics.Extensions;

namespace NGenerics.Tests.Extensions
{
    [TestFixture]
    public class DoubleExtensionsTests
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
}
