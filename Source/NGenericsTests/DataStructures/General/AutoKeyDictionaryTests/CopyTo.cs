/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
