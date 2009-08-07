/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System.Collections.Generic;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {

        [TestFixture]
        public class ForEach
        {
            [Test]
            public void Should_Iterate_Over_Each_Item_In_The_Collection()
            {
				IEnumerable<int> list = new List<int> { 1, 2, 3, 4, 5 };
                var total = 0;

                list.ForEach(x => total += x);

                Assert.AreEqual(total, 15);
            }
        }





    }
}
