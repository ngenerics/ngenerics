/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.Comparers;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ReverseComparerTests
{
    [TestFixture]
    public class Compare
    {
        [Test]
        public void Simple()
        {
            var comparer = new ReverseComparer<int>();

            Assert.AreEqual(comparer.Compare(2, 3), 1);
            Assert.AreEqual(comparer.Compare(3, 2), -1);
            Assert.AreEqual(comparer.Compare(0, 0), 0);
            Assert.AreEqual(comparer.Compare(0, 1), 1);
            Assert.AreEqual(comparer.Compare(1, 0), -1);
        }
    }
}