/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class GetEnumerator : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var enumerator = tree.GetEnumerator();

            var list = new List<KeyValuePair<int, string>>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

            Assert.AreEqual(list.Count, 6);
        }

        [Test]
        public void Interface()
        {
            var tree = GetTestTree();
            var enumerator = ((IEnumerable)tree).GetEnumerator();

            var list = new List<KeyValuePair<int, string>>();

            while (enumerator.MoveNext())
            {
                list.Add((KeyValuePair<int, string>)enumerator.Current);
            }

            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

            Assert.AreEqual(list.Count, 6);
        }

        [Test]
        public void InterfaceKeyValuePair()
        {
            IEnumerable<KeyValuePair<int, string>> tree = GetTestTree();
            var enumerator = tree.GetEnumerator();

            var list = new List<KeyValuePair<int, string>>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
            Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

            Assert.AreEqual(list.Count, 6);
        }

    }
}