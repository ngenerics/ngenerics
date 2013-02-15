/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class GetEnumerator
    {
        [Test]
        public void Simple()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
            IEnumerable<int> enumerable = target;
            var enumerator = enumerable.GetEnumerator();

            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual(2, current);

            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual(4, current);

            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual(9, current);
        }

        [Test]
        public void Interface()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
            IEnumerable enumerable = target;
            var enumerator = enumerable.GetEnumerator();

            enumerator.MoveNext();
            var current = (int)enumerator.Current;
            Assert.AreEqual(2, current);

            enumerator.MoveNext();
            current = (int)enumerator.Current;
            Assert.AreEqual(4, current);

            enumerator.MoveNext();
            current = (int)enumerator.Current;
            Assert.AreEqual(9, current);
        }
    }

    class GetEnumeratorImpl : GetEnumerator
    {
    }
}