/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System.Collections.Generic;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions.EnumerableExtensionsTests
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
