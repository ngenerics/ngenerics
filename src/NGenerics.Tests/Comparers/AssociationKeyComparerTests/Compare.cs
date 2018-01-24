/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.KeyValuePairKeyComparerTests
{
    [TestFixture]
    public class Compare
    {
        [Test]
        public void Simple()
        {
            var associationKeyComparer = new KeyComparer<int, string>();

            var association1 = new KeyValuePair<int, string>(5, "5");
            var association2 = new KeyValuePair<int, string>(5, "6");
            var association3 = new KeyValuePair<int, string>(3, "5");
            var association4 = new KeyValuePair<int, string>(5, "5");

            Assert.AreEqual(0, associationKeyComparer.Compare(association1, association2));
            Assert.AreEqual(1, associationKeyComparer.Compare(association1, association3));
            Assert.AreEqual(0, associationKeyComparer.Compare(association1, association4));

            Assert.AreEqual(0, associationKeyComparer.Compare(association2, association1));
            Assert.AreEqual(-1, associationKeyComparer.Compare(association3, association1));
            Assert.AreEqual(0, associationKeyComparer.Compare(association4, association1));
        }
    }
}
