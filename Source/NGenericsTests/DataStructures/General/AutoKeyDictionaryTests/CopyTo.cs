/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class CopyTo
    {
        [Test]
        public void Simple()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 1, 2, 3 };
            ICollection<int> collection = target;
            var pairs = new int[3];
            collection.CopyTo(pairs, 0);
            Assert.AreEqual(1, pairs[0]);
            Assert.AreEqual(2, pairs[1]);
            Assert.AreEqual(3, pairs[2]);
        }
    }
}
