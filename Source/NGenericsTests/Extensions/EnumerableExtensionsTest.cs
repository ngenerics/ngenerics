/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
